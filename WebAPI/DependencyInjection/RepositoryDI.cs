using ApplicationLayer.IRepository;
using ApplicationLayer.IRepository.Admin;
using InfrastructorLayer.Repository;
using InfrastructorLayer.Repository.Admin;

namespace WebAPI.DependencyInjection
{
    public static class RepositoryDI
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeInfo, EmployeeRepository>();
            services.AddScoped<IPostInfo, PostInfoRepository>();
            services.AddScoped<IEducation, EducationRepository>();
            services.AddScoped<IUserAccount, AccountRepository>();
            services.AddScoped<IRolePermission, RolePermissionRepository>();
            services.AddScoped<IMenu, MenuRepository>();
            services.AddScoped<IRole, RoleRepository>();

            return services;
        }
    }
}
