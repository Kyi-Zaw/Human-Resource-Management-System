using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using ApplicationLayer.Services;
using DomainLayer.Entities;
using InfrastructorLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructorLayer.Repository
{
    public class PostInfoRepository : IPostInfo
    {
        private readonly AppDbContext appDbContext;
        public PostInfoRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> AddAsync(PostInfoRequest postRequest)
        {
            var data = await appDbContext.PostInfo.FirstOrDefaultAsync(x => x.Code.ToLower().Trim() == postRequest.Code.ToLower().Trim());
            if (data is not null) return new ServiceResponse(false, "Duplicate Data Exist...");


            var entity = new PostInfo
            {
                PostID = Guid.NewGuid().ToString(),
                Code = postRequest.Code.Trim(),
                Description = postRequest.Description,
                Active = true,
                CreatedDate = DateTime.Now,
                CreatedUserID = "DFDB7579-F4DA-4334-BE84-0E57DF415560"
            };

            appDbContext.PostInfo.Add(entity);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Save Successful");
        }

        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var postInfo = await appDbContext.PostInfo.FindAsync(id);
            if (postInfo is null)
                new ServiceResponse(false, "User Not Found");

            appDbContext.PostInfo.Remove(postInfo!);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Delete SuccessFul");
        }

        public async Task<List<PostInfoDto>> GetAllAsync() =>
        await appDbContext.PostInfo.AsNoTracking().Select(o => new PostInfoDto
        {
            PostID = o.PostID,
            Code = o.Code,
            Description = o.Description,
            Active = o.Active,
            CreatedDate = o.CreatedDate,
            CreatedUserID = o.CreatedUserID,
            UpdatedDate = o.UpdatedDate,
            UpdatedUserID = o.UpdatedUserID
        }).ToListAsync();


        public async Task<PostInfoDto> GetByIDAsync(string id) =>
        await appDbContext.PostInfo.Where(x => x.PostID == id).Select(o => new PostInfoDto
        {
            PostID = o.PostID,
            Code = o.Code,
            Description = o.Description,
            Active = o.Active,
            CreatedDate = o.CreatedDate,
            CreatedUserID = o.CreatedUserID,
            UpdatedDate = o.UpdatedDate,
            UpdatedUserID = o.UpdatedUserID
        }).FirstOrDefaultAsync();

        public async Task<ServiceResponse> UpdateAsync(string id,PostInfoRequest PostInfo)
        {
            var data = await appDbContext.PostInfo.FirstOrDefaultAsync(x => x.PostID == id);

            if (data == null)
                return new ServiceResponse(false, "Position not found");

            data.PostID = id;
            data.Code = PostInfo.Code;
            data.Description = PostInfo.Description;

            appDbContext.PostInfo.Update(data);

            await SaveChangesAsync();

            return new ServiceResponse(true, "Updated Successful");
        }

        private async Task SaveChangesAsync() => await appDbContext.SaveChangesAsync();
    }
}
