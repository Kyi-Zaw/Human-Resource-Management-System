using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccount _userAccount;

        public AccountController(IUserAccount userAccount)
        {
            _userAccount = userAccount;
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody] UserRequest userDto)
        {
            var response = await _userAccount.CreateAccount(userDto);
            if (!response.Flag)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginDto)
        {
            var response = await _userAccount.Login(loginDto);
            if (!response.Flag)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
