using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using DomainLayer.Entities;
using InfrastructorLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<List<RolePermissionDto>> GetAllAsync()
        {
            throw new NotImplementedException();
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
