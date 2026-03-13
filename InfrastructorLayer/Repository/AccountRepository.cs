using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using InfrastructorLayer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationLayer.DTOs.Response;

namespace InfrastructorLayer.Repository
{
    public class AccountRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config) : IUserAccount
    {


        public async Task<Response.GrneralResponse> CreateAccount(UserRequest userDto)
        {
            if (userDto is null)
                return new GrneralResponse(false, "User data is null");

            var userExist = await userManager.FindByEmailAsync(userDto.Email);
            if (userExist is not null)
                return new GrneralResponse(false, "User already exist");

            var newUser = new ApplicationUser
            {
                Name = userDto.Name,
                Email = userDto.Email,
                PasswordHash = userDto.Password,
                UserName = userDto.Email
            };

            var createUser = await userManager.CreateAsync(newUser, userDto.Password);
            if (!createUser.Succeeded)
                return new GrneralResponse(false, "User creation failed");

            var checckAdminRole = await roleManager.FindByNameAsync("Admin");
            if (checckAdminRole is null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));

                await userManager.AddToRoleAsync(newUser, "Admin");
                return new GrneralResponse(false, "Account Created");
            }
            else
            {
                var checkUserRole = await roleManager.FindByNameAsync("User");
                if (checkUserRole is null)
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                    await userManager.AddToRoleAsync(newUser, "User");
                    return new GrneralResponse(true, "Account Created");

                }
            }

            return new GrneralResponse(true, "Account Created");

        }


        public async Task<LoginResponse> Login(LoginRequest loginDto)
        {
            if (loginDto is null)
                return new LoginResponse(false, "", "Login data is null");

            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user is null)
                return new LoginResponse(false, "", "User not found");

            var checkPassword = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!checkPassword)
                return new LoginResponse(false, "", "Invalid password");

            var getUserRole = await userManager.GetRolesAsync(user);
            var userSession = new UserSession(user.Id, user.Name, user.Email, getUserRole.First());


            string token = GenerateJwtToken(user, getUserRole.FirstOrDefault() ?? getUserRole.First());
            return new LoginResponse(true, token, "Login Success");
        }

        private string GenerateJwtToken(ApplicationUser user, string role)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(config["Jwt:Key"] ?? throw new InvalidOperationException("Jwt Key Not Found"));
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.Id),
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, user.Email),
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Name),
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = config["Jwt:Issuer"],
                Audience = config["Jwt:Audience"],
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
