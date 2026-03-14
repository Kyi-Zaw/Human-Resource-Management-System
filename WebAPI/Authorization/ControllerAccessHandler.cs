using InfrastructorLayer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Web.Api.Authorization
{
    public class ControllerAccessHandler : AuthorizationHandler<ControllerAccessRequirement>
    {
        private readonly AppDbContext _context;

        public ControllerAccessHandler(AppDbContext context)
        {
            _context = context;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context, ControllerAccessRequirement requirement)
        {
            var roleID = context.User.FindFirst(ClaimTypes.Role)?.Value;
           

            if (string.IsNullOrEmpty(roleID))
            {
                context.Fail();
                return;
            }

            var httpContext = context.Resource as HttpContext;
            if (httpContext == null)
            {
                context.Fail();
                return;
            }

            var controllerName = httpContext.GetRouteValue("controller")?.ToString();
            if (string.IsNullOrEmpty(controllerName))
            {
                context.Fail();
                return;
            }

            var AName = httpContext.GetRouteValue("action");
            if (AName is null)
            {
                context.Fail();
                return;
            }

            var permission = await _context.RolePermissions
                .FirstOrDefaultAsync(p => p.RoleName== roleID && p.ControllerName == controllerName );

            if (permission != null && permission.IsAllowed)
            {
                context.Succeed(requirement);

            }
            else
            {
                context.Fail();
            }
        }
    }

}
