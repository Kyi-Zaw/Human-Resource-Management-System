using ApplicationLayer.DTOs;
using ApplicationLayer.RequestModel;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IFileUploadService
    {
        Task<HttpResponseMessage> Create(IBrowserFile file,string folderName,string fileName);
        Task<HttpResponseMessage> Download(string filename);
    }
}
