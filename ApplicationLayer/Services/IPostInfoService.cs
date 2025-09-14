using ApplicationLayer.DTOs;
using ApplicationLayer.RequestModel;

namespace ApplicationLayer.Services
{
    public interface IPostInfoService
    {
        Task<ServiceResponse> AddAsync(PostInfoRequest postInfoRequest);
        Task<ServiceResponse> UpdateAsync(string id, PostInfoRequest postInfoRequest);
        Task<ServiceResponse> DeleteAsync(string id);
        Task<List<PostInfoDto>> GetAllAsync();
        Task<PostInfoDto> GetByIDAsync(string id);
    }
}
