using ApplicationLayer.DTOs;
using ApplicationLayer.RequestModel.Admin;
using System.Net.Http.Json;


namespace ApplicationLayer.Services.Admin
{
    public class RoleService : IRole
    {
        private readonly HttpClient httpClient;

        public RoleService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient.CreateClient("API");
        }

        public async Task<ServiceResponse> AddAsync(RoleRequest RoleRequest)
        {
            var data = await httpClient.PostAsJsonAsync("api/role/add", RoleRequest);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public Task<ServiceResponse> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoleDto>> GetAllAsync()
        {
            return await httpClient.GetFromJsonAsync<List<RoleDto>>("api/role/getallasync")!;
        }

        public Task<List<RoleDto>> GetAllAsyncByRoleName(string? roleName)
        {
            throw new NotImplementedException();
        }

        public Task<RoleDto> GetByIDAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateAsync(string id, RoleRequest RoleRequest)
        {
            throw new NotImplementedException();
        }
    }
}
