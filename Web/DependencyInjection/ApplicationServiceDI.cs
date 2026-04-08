using ApplicationLayer.Services;
using ApplicationLayer.Services.Admin;

namespace Web.DependencyInjection
{
    public static class ApplicationServiceDI
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPostInfoService, PostInfoService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<IUserAccount, AccountService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            services.AddScoped<IMenu, MenuService>();
            services.AddScoped<IRole, RoleService>();

            return services;
        }
    }
}
