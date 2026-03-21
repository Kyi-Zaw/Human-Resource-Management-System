using ApplicationLayer.IRepository.Admin;
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

        [Authorize(Roles = "Admin")]
        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var data = await menus.GetByIDAsync(id);
            return Ok(data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] MenuRequest menuRequest)
        {
            var result = await this.menus.UpdateAsync(id, menuRequest);
            return Ok(result);
        }
    }
}
