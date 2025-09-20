using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;


namespace ApplicationLayer.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly HttpClient httpClient;

        public FileUploadService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> Create(IBrowserFile file,string folderName,string fileName)
        {

            var extension = Path.GetExtension(file.Name).ToLower();

            using var stream = file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024); // 10MB
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            var content = new MultipartFormDataContent();
            var ext = Path.GetExtension(file.Name).ToLower();
            content.Add(new StreamContent(new MemoryStream(ms.ToArray())), "file", fileName);
            var response = await httpClient.PostAsync($"api/upload/save/{folderName}", content);
            return response;
        }

        public async Task<HttpResponseMessage> Download(string filename)
        {
            var response = await httpClient.GetAsync($"api/upload/download/{filename}");            
            return response;
        }
    }
}
