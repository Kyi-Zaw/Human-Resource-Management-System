using ApplicationLayer.DTOs;
using ApplicationLayer.RequestModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepository
{
    public interface IMenu
    {
        Task<ServiceResponse> AddAsync(MenuRequest rolePermissionRequest);
        Task<ServiceResponse> UpdateAsync(string id, MenuRequest rolePermissionRequest);

        Task<ServiceResponse> DeleteAsync(string id);

        Task<List<MenuDto>> GetAllAsync();

        Task<List<MenuDto>> GetAllAsyncByRole(string? roleName);
        Task<MenuDto> GetByIDAsync(string id);
    }
}
