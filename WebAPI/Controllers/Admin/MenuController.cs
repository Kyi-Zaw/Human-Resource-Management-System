using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using ApplicationLayer.RequestModel.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        public readonly IMenu menus;

        public MenuController(IMenu menus)
        {
            this.menus = menus;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] MenuRequest menusRequest)
        {
            var result = await this.menus.AddAsync(menusRequest);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllAsyncByRole")]
        public async Task<IActionResult> GetAllAsyncByRole()
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await this.menus.GetAllAsyncByRole(role);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await this.menus.GetAllAsync();
            return Ok(result);
        }
    }
}
