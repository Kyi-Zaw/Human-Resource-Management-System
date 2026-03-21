using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository.Admin;
using ApplicationLayer.RequestModel.Admin;
using DomainLayer.Entities;
using InfrastructorLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;


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

            var menus = await (
                             from rp in appDbContext.RolePermissions
                             join m in appDbContext.Menus
                                 on rp.MenuID equals m.MenuID
                             where rp.RoleName == roleName
                             select m
                         ).Select(rm => new MenuDto
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

        public async Task<MenuDto> GetByIDAsync(string id) =>
           await appDbContext.Menus.Where(x => x.MenuID == id).Select(m => new MenuDto
           {
               MenuID = m.MenuID,
               ControllerName = m.ControllerName,
               MenuName = m.MenuName,
               Url = m.Url,
               Icon = m.Icon,
               ParentId = m.ParentId,
               SeniorOrderNo = m.SeniorOrderNo,
           }).FirstOrDefaultAsync();

        public async Task<ServiceResponse> UpdateAsync(string id, MenuRequest menuRequest)
        {
            var data = await appDbContext.Menus.FirstOrDefaultAsync(x => x.MenuID == id);

            if (data == null)
                return new ServiceResponse(false, "Menus not found");

            data.MenuID= id;
            data.MenuName = menuRequest.MenuName;
            data.ControllerName = menuRequest.ControllerName;
            data.Url = menuRequest.Url;
            data.Icon = menuRequest.Icon;
            data.ParentId = menuRequest.Parent;
            data.SeniorOrderNo = menuRequest.OrderNo;
          

            appDbContext.Menus.Update(data);

            await SaveChangesAsync();

            return new ServiceResponse(true, "Updated Successful");
        }

        private async Task SaveChangesAsync() => await appDbContext.SaveChangesAsync();

    }
}
