using ApplicationLayer.DTOs;
using ApplicationLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IRolePermissionService
    {
        Task<ServiceResponse> AddAsync(RolePermissionRequest rolePermissionRequest);
        Task<ServiceResponse> UpdateAsync(string id, RolePermissionRequest rolePermissionRequest);

        Task<ServiceResponse> DeleteAsync(string id);

        Task<List<RolePermissionDto>> GetAllAsyncByRole();

        Task<List<RolePermissionDto>> GetAllAsync();
        Task<RolePermissionDto> GetByIDAsync(string id);
    }
}
