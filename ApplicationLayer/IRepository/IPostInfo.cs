using ApplicationLayer.DTOs;
using ApplicationLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IRepository
{
    public interface IPostInfo
    {
        Task<ServiceResponse> AddAsync(PostInfoRequest postInfoRequest);
        Task<ServiceResponse> UpdateAsync(string id, PostInfoRequest postInfoRequest);
        Task<ServiceResponse> DeleteAsync(string id);
        Task<List<PostInfoDto>> GetAllAsync();
        Task<PostInfoDto> GetByIDAsync(string id);
    }
}
