using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using ApplicationLayer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostInfoController : ControllerBase
    {
        public readonly IPostInfo postInfo;

        public PostInfoController(IPostInfo postInfo)
        {
            this.postInfo = postInfo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await postInfo.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var data = await postInfo.GetByIDAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PostInfoRequest postInfoRequest)
        {
            var result = await this.postInfo.AddAsync(postInfoRequest);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id,[FromBody] PostInfoRequest postInfoRequest)
        {
            var result = await this.postInfo.UpdateAsync(id, postInfoRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await postInfo.DeleteAsync(id);
            return Ok(result);
        }
    }
}
