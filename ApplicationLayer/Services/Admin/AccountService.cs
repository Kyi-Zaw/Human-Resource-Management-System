using ApplicationLayer.DTOs;
using ApplicationLayer.GenericsModels;
using ApplicationLayer.IRepository.Admin;
using ApplicationLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static ApplicationLayer.DTOs.Response;
using static System.Net.WebRequestMethods;

namespace ApplicationLayer.Services.Admin
{
    public class AccountService(HttpClient httpClient) : IUserAccount
    {
        public Task<GrneralResponse> CreateAccount(UserRequest userRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var response = await httpClient.PostAsync("api/account/login/", Generics.GenerateStringContent(Generics.SerializeObj(loginRequest)));



            if (!response.IsSuccessStatusCode)
                return new LoginResponse(false, null!, "Login Failed");

           

            var apiResopnse = await response.Content.ReadAsStringAsync();

            httpClient.DefaultRequestHeaders.Authorization =
               new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiResopnse);
            return Generics.DescerializeJsonString<LoginResponse>(apiResopnse);
        }
    }
}
