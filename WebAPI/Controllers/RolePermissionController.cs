using ApplicationLayer.IRepository.Admin;
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
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RolePermissionRequest rolePermissionRequest)
        {
            var result = await this.rolePermission.AddAsync(rolePermissionRequest);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllAsyncByRole")]
        public async Task<IActionResult> GetAllAsyncByRole()
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await this.rolePermission.GetAllAsyncByRole(role);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await this.rolePermission.GetAllAsync();
            return Ok(result);
        }
    }
}
