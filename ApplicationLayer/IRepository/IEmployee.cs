using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepository;

public interface IEmployee
{
    Task<ServiceResponse> AddAsync(EmployeeDto employee);
    Task<ServiceResponse> UpdateAsync(EmployeeDto id);
    Task<ServiceResponse> DeleteAsync(string id);
    Task<List<EmployeeDto>> GetAllAsync();
    Task<EmployeeDto> GetByIDAsync(string id);

}
