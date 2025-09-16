using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await education.GetAllAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EducationRequest educationRequest)
        {
            var result = await this.education.CreateAsync(educationRequest);
            return Ok(result);
        }



    }
}
