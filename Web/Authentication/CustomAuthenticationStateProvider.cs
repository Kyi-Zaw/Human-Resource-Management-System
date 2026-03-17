using ApplicationLayer.GenericsModels;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace Web.Authentication
{
    public class CustomAuthenticationStateProvider(ILocalStorageService localStorageService) : AuthenticationStateProvider
    {
        private ClaimsPrincipal anonymous= new (new ClaimsIdentity());
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                string token = await localStorageService.GetItemAsStringAsync("token");

                if (string.IsNullOrWhiteSpace(token))
                    return await Task.FromResult(new AuthenticationState(anonymous));

                var claims = Generics.GetClaimsFromToken(token);
                var claimsPrincipal = Generics.SetClaimsPrincipal(claims);
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(anonymous));
            }
        }

        public async Task UpdateAuthenticationState(string? token)
        {
            ClaimsPrincipal claimsPrincipal = new();
            if(!string.IsNullOrWhiteSpace(token))
            {
                var userSession = Generics.GetClaimsFromToken(token);
                claimsPrincipal = Generics.SetClaimsPrincipal(userSession);
                await localStorageService.SetItemAsStringAsync("token",token);
                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
            }
            else
            {
                claimsPrincipal = anonymous;
                await localStorageService.RemoveItemAsync("token");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task Logout()
        {
            await localStorageService.RemoveItemAsync("token");

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(anonymous))
            );
        }
    } 
}
