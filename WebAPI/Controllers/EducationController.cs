using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {

        public readonly IEducation education;

        public EducationController(IEducation education)
        {
            this.education = education;
        }

        [Authorize(Policy = "ControllerAccess")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await education.GetAllAsync();
            return Ok(data);
        }

        [Authorize(Policy = "ControllerAccess")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var data = await education.GetByIdAsync(id);
            return Ok(data);
        }

        [Authorize(Policy = "ControllerAccess")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EducationRequest educationRequest)
        {
            var result = await this.education.CreateAsync(educationRequest);
            return Ok(result);
        }

        [Authorize(Policy = "ControllerAccess")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] EducationRequest educationRequest)
        {
            var result = await this.education.UpdateAsync(id, educationRequest);
            return Ok(result);
        }

        [Authorize(Policy = "ControllerAccess")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await education.DeleteAsync(id);
            return Ok(result);
        }

    }
}
