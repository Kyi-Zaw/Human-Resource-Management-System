using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/upload")]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public UploadController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("save{moduleFolder,formFolder}")]
        public async Task<IActionResult> UploadExcel(string moduleFolder, string formFolder,IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please insert file.");

            var ext = Path.GetExtension(file.FileName).ToLower();
          
            var fileName = $"{file.FileName}_{DateTime.Now:dd-M-yyyy_hh-mm-ss_tt}{ext}";
            var folder = Path.Combine("Files/"+moduleFolder +"/", formFolder);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var filePath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { Message = "Upload Successfully", FileName = fileName });
        }
    }
}
