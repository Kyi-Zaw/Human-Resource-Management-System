using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using ApplicationLayer.Services;
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
public class EmployeeRepository : IEmployeeInfo
{
    private readonly AppDbContext appDbContext;
    public EmployeeRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<ServiceResponse> AddAsync(EmployeeInfoRequest employee)
    {
        var data =await appDbContext.Employees.FirstOrDefaultAsync(x => x.Name.ToLower().Trim() == employee.Name.ToLower().Trim());
        if (data is not null) return new ServiceResponse(false,"Duplicate Data Exist...");


        var entity = new Employee
        {
            EmployeeID = Guid.NewGuid().ToString(), 
            Name = employee.Name.Trim(),
            Address = employee.Address,
            Active = true,
            CreatedDate = DateTime.Now,
            CreatedUserID = "DFDB7579-F4DA-4334-BE84-0E57DF415560"
        };

        appDbContext.Employees.Add(entity);
        await SaveChangesAsync();
        return new ServiceResponse(true, "Save Successful");
    }

    public async Task<ServiceResponse> DeleteAsync(string id)
    {
        var employee = await appDbContext.Employees.FindAsync(id);
        if (employee is null)
            new ServiceResponse(false, "User Not Found");

        appDbContext.Employees.Remove(employee);
        await SaveChangesAsync();
        return new ServiceResponse(true, "Delete SuccessFul");
    }

    public async Task<List<EmployeeDto>> GetAllAsync() => 
        await appDbContext.Employees.AsNoTracking().Select(o=> new EmployeeDto
        {
            EmployeeID = o.EmployeeID,
            Name = o.Name,
            Address = o.Address,
        }).ToListAsync();

    public async Task<EmployeeDto> GetByIDAsync(string id) =>
    await appDbContext.Employees.Where(x => x.EmployeeID == id).Select(o => new EmployeeDto
    {
        EmployeeID = o.EmployeeID,
        Name = o.Name,
        Address = o.Address,
    }).FirstOrDefaultAsync();


    public async Task<ServiceResponse> UpdateAsync(string id,EmployeeInfoRequest employeeInfo)
    {
       
        var data = await appDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeID == id);

        if (data == null)
            return new ServiceResponse(false, "Employee not found");

        data.EmployeeID = id;
        data.Name = employeeInfo.Name;
        data.Address = employeeInfo.Address; 

        appDbContext.Employees.Update(data); 

        await SaveChangesAsync();

        return new ServiceResponse(true, "Updated Successful");

    }

    private async Task SaveChangesAsync() => await appDbContext.SaveChangesAsync();
}
}
