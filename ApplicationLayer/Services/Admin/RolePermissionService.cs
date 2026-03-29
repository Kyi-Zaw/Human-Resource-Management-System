using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Admin
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly HttpClient httpClient;

        public RolePermissionService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient.CreateClient("API");
        }
        public async Task<ServiceResponse> AddAsync(RolePermissionRequest rolePermissionRequest)
        {
            var data = await httpClient.PostAsJsonAsync("api/rolepermission/add", rolePermissionRequest);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public Task<ServiceResponse> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RolePermissionDto>> GetAllAsyncByRole(string roleID)
        {
           return await httpClient.GetFromJsonAsync<List<RolePermissionDto>>($"api/rolepermission/getallasyncbyrole/{roleID}")!;
        }

        public async Task<List<RolePermissionDto>> GetAllAsync()
        {
            return await httpClient.GetFromJsonAsync<List<RolePermissionDto>>("api/rolepermission/getallasync")!;
        }

        public Task<RolePermissionDto> GetByIDAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateAsync(string id, RolePermissionRequest rolePermissionRequest)
        {
            throw new NotImplementedException();
        }
    }
}
