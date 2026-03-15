using ApplicationLayer.DTOs;
using ApplicationLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationLayer.GenericsModels
{
    public static class Generics
    {
        public static ClaimsPrincipal SetClaimsPrincipal(UserSession model)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, model.Id!),
                new (ClaimTypes.Name, model.Name!),
                new (ClaimTypes.Email, model.Email!),
                new (ClaimTypes.Role, model.Role!)
            }, "JwtAuth"));
        }

        public static UserSession GetClaimsFromToken(string jwtToken)
        {
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);
            var claims = token.Claims;

            string type = ClaimTypes.NameIdentifier;

            string id = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
           

            return new UserSession
            (
               claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
               claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
               claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
               claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value
            );

        }

        public static JsonSerializerOptions JsonOptions() => new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true,
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip 
        };

        public static string SerializeObj<T>(T modelObj) => JsonSerializer.Serialize(modelObj,JsonOptions());

        public static T DescerializeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString, JsonOptions())!;

        public static StringContent GenerateStringContent(string serializedObj) => new StringContent(serializedObj, Encoding.UTF8, "application/json"); 
    }
}
