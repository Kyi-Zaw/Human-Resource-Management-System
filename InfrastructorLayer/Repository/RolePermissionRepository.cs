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
           


            var entity = new RolePermissions
            {
                RolePermissionID = Guid.NewGuid().ToString().ToUpper(),
                MenuID = rolePermissionRequest.MenuID,        
                RoleName = rolePermissionRequest.RoleName,
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

        public async Task<List<RolePermissionDto>> GetAllAsyncByRole(string roleName)
        {

            var menus = await appDbContext.RolePermissions
                .Where(rm => rm.RoleName == roleName)    
                .Select(rm => new RolePermissionDto
                {
                    RolePermissionID = rm.RolePermissionID,
                    RoleName = rm.RoleName,
                    MenuID = rm.MenuID,
                    IsAllowed = rm.IsAllowed,
                   
                })
                .ToListAsync();
            return menus;
        }


        public async Task<List<RolePermissionDto>> GetAllAsync()
        {

            var menus = await appDbContext.RolePermissions
                .Select(rm => new RolePermissionDto
                {
                    RolePermissionID = rm.RolePermissionID,
                    RoleName = rm.RoleName,
                    MenuID = rm.MenuID,
                    IsAllowed = rm.IsAllowed,
                  
                })
                .ToListAsync();
            return menus;



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
