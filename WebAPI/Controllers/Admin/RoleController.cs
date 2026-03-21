using ApplicationLayer.IRepository.Admin;
using ApplicationLayer.RequestModel.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public readonly IRole role;

        public RoleController(IRole role)
        {
            this.role = role;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RoleRequest menusRequest)
        {
            var result = await this.role.AddAsync(menusRequest);
            return Ok(result);
        }

        [HttpGet("GetAllAsyncByRole/{roleName}")]
        public async Task<IActionResult> GetAllAsyncByRole(string roleName)
        {
            var result = await this.role.GetAllAsyncByRoleName(roleName);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await this.role.GetAllAsync();
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var data = await role.GetByIDAsync(id);
            return Ok(data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] RoleRequest roleRequest)
        {
            var result = await this.role.UpdateAsync(id, roleRequest);
            return Ok(result);
        }
    }
}
