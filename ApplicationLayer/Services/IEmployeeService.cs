using ApplicationLayer.DTOs;
using DomainLayer.Entities;

namespace ApplicationLayer.Services;

public interface IEmployeeService
{
    Task<ServiceResponse> AddAsync(EmployeeDto employee);
    Task<ServiceResponse> UpdateAsync(EmployeeDto employee);
    Task<ServiceResponse> DeleteAsync(string id);
    Task<List<EmployeeDto>> GetAllAsync();
    Task<EmployeeDto> GetByIDAsync(string id);
}
