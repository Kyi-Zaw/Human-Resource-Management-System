using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        public readonly IRolePermission rolePermission;

        public RolePermissionController(IRolePermission rolePermission)
        {
            this.rolePermission = rolePermission;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RolePermissionRequest rolePermissionRequest)
        {
            var result = await this.rolePermission.AddAsync(rolePermissionRequest);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await this.rolePermission.GetAllAsync(role);
            return Ok(result);
        }
    }
}
