using ApplicationLayer.DTOs;
using ApplicationLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepository
{
    public interface IEducation
    {
        Task<ServiceResponse> CreateAsync(EducationRequest request);
        Task<EducationHeaderDto> GetByIdAsync(string id);
        Task<List<EducationHeaderDto>> GetAllAsync();
        Task<ServiceResponse> UpdateAsync(string id, EducationRequest request);
        Task<ServiceResponse> DeleteAsync(string id);
    }
}
