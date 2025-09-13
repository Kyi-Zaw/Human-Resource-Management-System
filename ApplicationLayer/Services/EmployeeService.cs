using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository;
using DomainLayer.Entities;
using System.Net.Http;
using System.Net.Http.Json;

namespace ApplicationLayer.Services;

public class EmployeeService : IEmployeeService
{
    private readonly HttpClient httpClient;

    public EmployeeService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public async Task<ServiceResponse> AddAsync(EmployeeDto employee)
    {
        var data = await httpClient.PostAsJsonAsync("api/employee",employee);
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response!;
    }

    public async Task<ServiceResponse> DeleteAsync(string id)
    {
        var data = await httpClient.DeleteAsync($"api/employee/{id}");
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response!;
    }

    public async Task<List<EmployeeDto>> GetAllAsync() => 
        await httpClient.GetFromJsonAsync<List<EmployeeDto>>("api/employee")!;
   

    public async Task<EmployeeDto> GetByIDAsync(string id) =>
    await httpClient.GetFromJsonAsync<EmployeeDto>($"api/employee/{id}")!;

    public async Task<ServiceResponse> UpdateAsync(EmployeeDto employee)
    {
        var data = await httpClient.PutAsJsonAsync("api/employee", employee);
        var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
        return response!;
    }
}
