using ApplicationLayer.DTOs;
using ApplicationLayer.RequestModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepository.Admin
{
    public interface IRole
    {
        Task<ServiceResponse> AddAsync(RoleRequest RoleRequest);
        Task<ServiceResponse> UpdateAsync(string id, RoleRequest RoleRequest);

        Task<ServiceResponse> DeleteAsync(string id);

        Task<List<RoleDto>> GetAllAsync();

        Task<List<RoleDto>> GetAllAsyncByRoleName(string? roleName);
        Task<RoleDto> GetByIDAsync(string id);

    }
}
