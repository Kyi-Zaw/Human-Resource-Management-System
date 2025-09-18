using ApplicationLayer.DTOs;
using ApplicationLayer.RequestModel;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepository;

public interface IEmployeeInfo
{
    Task<ServiceResponse> AddAsync(EmployeeInfoRequest employeeInfoRequest);
    Task<ServiceResponse> UpdateAsync(string id, EmployeeInfoRequest employeeInfoRequest);
    Task<ServiceResponse> DeleteAsync(string id);
    Task<List<EmployeeDto>> GetAllAsync();
    Task<EmployeeDto> GetByIDAsync(string id);

}
