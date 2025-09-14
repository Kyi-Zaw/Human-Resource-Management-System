using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class PostInfoService : IPostInfoService
    {
        private readonly HttpClient httpClient;

        public PostInfoService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<ServiceResponse> AddAsync(PostInfoRequest postInfoRequest)
        {
            var data = await httpClient.PostAsJsonAsync("api/postinfo", postInfoRequest);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var data = await httpClient.DeleteAsync($"api/postinfo/{id}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<List<PostInfoDto>> GetAllAsync() =>
        await httpClient.GetFromJsonAsync<List<PostInfoDto>>("api/postinfo")!;

        public async Task<PostInfoDto> GetByIDAsync(string id) =>
        await httpClient.GetFromJsonAsync<PostInfoDto>($"api/postinfo/{id}")!;

        public async Task<ServiceResponse> UpdateAsync(string id, PostInfoRequest postInfoRequest)
        {
            var data = await httpClient.PutAsJsonAsync($"api/postinfo/{id}", postInfoRequest);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }
    }
}
