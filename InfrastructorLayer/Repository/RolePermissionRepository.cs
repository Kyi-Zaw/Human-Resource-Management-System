using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using DomainLayer.Entities;
using InfrastructorLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructorLayer.Repository
{
    public class RolePermissionRepository : IRolePermission 
    {
        private readonly AppDbContext appDbContext;
        public RolePermissionRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> AddAsync(RolePermissionRequest rolePermissionRequest)
        {
            var data = await appDbContext.RolePermissions.FirstOrDefaultAsync(x => x.RoleName.ToLower().Trim() == rolePermissionRequest.RoleName.ToLower().Trim()
                                                                                  && x.ControllerName == rolePermissionRequest.ControllerName.ToLower().Trim());
            if (data is not null) return new ServiceResponse(false, "Duplicate Data Exist...");


            var entity = new RolePermissions
            {
                RolePermissionID = Guid.NewGuid().ToString().ToUpper(),
                MenuName = rolePermissionRequest.MenuName,
                Url = rolePermissionRequest.Url,
                Icon = rolePermissionRequest.Icon,
                ParentId = rolePermissionRequest.Parent,
                Order = rolePermissionRequest.OrderNo,
                RoleName = rolePermissionRequest.RoleName,
                ControllerName = rolePermissionRequest.ControllerName,              
                IsAllowed = rolePermissionRequest.IsAllowed,
            };

            appDbContext.RolePermissions.Add(entity);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Save Successful");
        }

        public Task<ServiceResponse> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RolePermissionDto>> GetAllAsync(string roleName)
        {

            var menus = await appDbContext.RolePermissions
                .Where(rm => rm.RoleName == roleName)    
                .OrderBy(rm => rm.Order)
                .Select(rm => new RolePermissionDto
                {
                    RolePermissionID = rm.RolePermissionID,
                    RoleName = rm.RoleName,
                    MenuName = rm.MenuName,
                    ControllerName = rm.ControllerName,
                    IsAllowed = rm.IsAllowed,
                    Url = rm.Url,
                    Icon = rm.Icon,
                    ParentId = rm.ParentId,
                    OrderNo = rm.Order,
                })
                .ToListAsync();
            menus = BuildMenuTree(menus);
            return menus;



        }

        public List<RolePermissionDto> BuildMenuTree(List<RolePermissionDto> menus)
        {
            var lookup = menus.ToLookup(m => m.ParentId);

            List<RolePermissionDto> Build(string? parentId)
            {
                return lookup[parentId]
                    .Select(m => new RolePermissionDto
                    {
                        RolePermissionID = m.RolePermissionID,
                        RoleName = m.RoleName,
                        ControllerName = m.ControllerName,
                        MenuName = m.MenuName,
                        IsAllowed = m.IsAllowed,
                        Url = m.Url,
                        Icon = m.Icon,
                        ParentId = m.ParentId,
                        OrderNo = m.OrderNo,
                        Children = Build(m.RolePermissionID)
                    })
                    .OrderBy(m => m.OrderNo)
                    .ToList();
            }

            return Build(null); // root menu
        }

        public Task<RolePermissionDto> GetByIDAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateAsync(string id, RolePermissionRequest rolePermissionRequest)
        {
            throw new NotImplementedException();
        }

        private async Task SaveChangesAsync() => await appDbContext.SaveChangesAsync();
    }
}
