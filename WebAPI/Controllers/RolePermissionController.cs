using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RolePermissionRequest rolePermissionRequest)
        {
            var result = await this.rolePermission.AddAsync(rolePermissionRequest);
            return Ok(result);
        }
    }
}
