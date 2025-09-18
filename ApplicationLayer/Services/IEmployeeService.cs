using ApplicationLayer.DTOs;
using ApplicationLayer.RequestModel;

namespace ApplicationLayer.Services
{
    public interface IEmployeeService
    {
        Task<ServiceResponse> AddAsync(EmployeeInfoRequest employeeInfoRequest);
        Task<ServiceResponse> UpdateAsync(string id, EmployeeInfoRequest employeeInfoRequest);
        Task<ServiceResponse> DeleteAsync(string id);
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> GetByIDAsync(string id);
    }
}
