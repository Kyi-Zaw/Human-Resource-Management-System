using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository.Admin;
using ApplicationLayer.RequestModel;
using ApplicationLayer.RequestModel.Admin;
using InfrastructorLayer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationLayer.DTOs.Response;

namespace InfrastructorLayer.Repository.Admin
{
    public class RoleRepository(RoleManager<IdentityRole> roleManager) : IRole
    {
        public async Task<ServiceResponse> AddAsync(RoleRequest RoleRequest)
        {
            var checkUserRole = await roleManager.FindByNameAsync(RoleRequest.RoleName);

            if (checkUserRole is null)
            {
                await roleManager.CreateAsync(new IdentityRole(RoleRequest.RoleName));
                return new ServiceResponse(true, "Account Created");
            }
            else
            {
                return new ServiceResponse(false, "Role already exist");
            }
        }

        public Task<ServiceResponse> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoleDto>> GetAllAsync()=>
         await roleManager.Roles.Select(o => new RoleDto
         {
            RoleID = o.Id,
            RoleName = o.Name,
          
         }).ToListAsync();

    public Task<List<RoleDto>> GetAllAsyncByRoleName(string? roleName)
        {
            throw new NotImplementedException();
        }

        public Task<RoleDto> GetByIDAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateAsync(string id, RoleRequest RoleRequest)
        {
            throw new NotImplementedException();
        }



    }
}
