using ApplicationLayer.DTOs;
using ApplicationLayer.RequestModel;
using ApplicationLayer.RequestModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class MenuService : IMenu
    {
        private readonly HttpClient httpClient;

        public MenuService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient.CreateClient("API");
        }
        public async Task<ServiceResponse> AddAsync(MenuRequest menuRequest)
        {
            var data = await httpClient.PostAsJsonAsync("api/menu/add", menuRequest);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public Task<ServiceResponse> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MenuDto>> GetAllAsync()
        {
            return await httpClient.GetFromJsonAsync<List<MenuDto>>("api/menu/getallasync")!;
        }

        public async Task<List<MenuDto>> GetAllAsyncByRole()
        {
            return await httpClient.GetFromJsonAsync<List<MenuDto>>("api/menu/getallasyncbyrole")!;

        }

        public Task<MenuDto> GetByIDAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateAsync(string id, MenuRequest rolePermissionRequest)
        {
            throw new NotImplementedException();
        }
    }
}
