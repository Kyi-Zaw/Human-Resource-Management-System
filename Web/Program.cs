using ApplicationLayer.IRepository;
using ApplicationLayer.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NetcodeHub.Packages.Components.Toast;
using Web;
using Web.Authentication;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7227") });

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();


builder.Services.AddScoped<JwtHandler>();

builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri("https://localhost:7227");
})
.AddHttpMessageHandler<JwtHandler>();

builder.Services.AddScoped<IEmployeeService,EmployeeService>();
builder.Services.AddScoped<IPostInfoService, PostInfoService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddScoped<IUserAccount,AccountService>();
builder.Services.AddScoped<IRolePermissionService, RolePermissionService>();



builder.Services.AddScoped<ToastService>();

await builder.Build().RunAsync();
