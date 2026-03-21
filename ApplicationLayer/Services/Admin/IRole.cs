using ApplicationLayer.DTOs;
using ApplicationLayer.RequestModel.Admin;


namespace ApplicationLayer.Services.Admin
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
