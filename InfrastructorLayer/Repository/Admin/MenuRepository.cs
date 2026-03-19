using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel.Admin;
using DomainLayer.Entities;
using InfrastructorLayer.Data;
using Microsoft.EntityFrameworkCore;


namespace InfrastructorLayer.Repository.Admin
{
    public class MenuRepository : IMenu
    {
        private readonly AppDbContext appDbContext;
        public MenuRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> AddAsync(MenuRequest menuRequest)
        {
           


            var entity = new Menu
            {
                MenuID = Guid.NewGuid().ToString().ToUpper(),
                MenuName = menuRequest.MenuName,
                Url = menuRequest.Url,
                Icon = menuRequest.Icon,
                ParentId = menuRequest.Parent,
                SeniorOrderNo = menuRequest.OrderNo,
                ControllerName = menuRequest.ControllerName,
            };

            appDbContext.Menus.Add(entity);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Save Successful");
        }

        public Task<ServiceResponse> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MenuDto>> GetAllAsyncByRole(string roleName)
        {

            var menus = await appDbContext.RolePermissions
                .Where(rm => rm.RoleName == roleName)
                .OrderBy(rm => rm.Order)
                .Select(rm => new MenuDto
                {
                    MenuID = rm.RolePermissionID,
                    MenuName = rm.MenuName,
                    ControllerName = rm.ControllerName,
                    Url = rm.Url,
                    Icon = rm.Icon,
                    ParentId = rm.ParentId,
                    SeniorOrderNo = rm.Order,
                })
                .ToListAsync();
            menus = BuildMenuTree(menus);
            return menus;
        }


        public async Task<List<MenuDto>> GetAllAsync()
        {

            var menus = await appDbContext.Menus
                .OrderBy(rm => rm.SeniorOrderNo)
                .Select(rm => new MenuDto
                {
                    MenuID = rm.MenuID,
                    MenuName = rm.MenuName,
                    ControllerName = rm.ControllerName,
                    Url = rm.Url,
                    Icon = rm.Icon,
                    ParentId = rm.ParentId,
                    SeniorOrderNo = rm.SeniorOrderNo,
                })
                .ToListAsync();
            menus = BuildMenuTree(menus);
            return menus;
        }

        public List<MenuDto> BuildMenuTree(List<MenuDto> menus)
        {
            var lookup = menus.ToLookup(m => m.ParentId);

            List<MenuDto> Build(string? parentId)
            {
                return lookup[parentId]
                    .Select(m => new MenuDto
                    {
                        MenuID = m.MenuID,
                        ControllerName = m.ControllerName,
                        MenuName = m.MenuName,
                        Url = m.Url,
                        Icon = m.Icon,
                        ParentId = m.ParentId,
                        SeniorOrderNo = m.SeniorOrderNo,
                        Children = Build(m.MenuID)
                    })
                    .OrderBy(m => m.SeniorOrderNo)
                    .ToList();
            }

            return Build(null); 
        }

        public Task<MenuDto> GetByIDAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateAsync(string id, MenuRequest menuRequest)
        {
            throw new NotImplementedException();
        }

        private async Task SaveChangesAsync() => await appDbContext.SaveChangesAsync();

    }
}
