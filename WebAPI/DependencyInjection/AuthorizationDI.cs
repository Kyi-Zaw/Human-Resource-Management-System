using Microsoft.AspNetCore.Authorization;
using Web.Api.Authorization;

namespace WebAPI.DependencyInjection
{
    public static class AuthorizationDI
    {
        public static IServiceCollection AddAuthorizationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationHandler, ControllerAccessHandler>();
            return services;
        }
    }
}
