using ApplicationLayer.DTOs;
using ApplicationLayer.IRepository;
using ApplicationLayer.RequestModel;
using DomainLayer.Entities;
using InfrastructorLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructorLayer.Repository
{
    public class EducationRepository : IEducation
    {
        private readonly AppDbContext _context;
        public EducationRepository(AppDbContext context) => _context = context;

        public async Task<ServiceResponse> CreateAsync(EducationRequest request)
        {
            string iD = Guid.NewGuid().ToString();

            var header = new EducationHeader
            {
                EducationHaderID = iD,
                EmployeeID = request.EmployeeID,
                CreatedUserID = "DFDB7579-F4DA-4334-BE84-0E57DF415560",
                CreatedDate = DateTime.Now,
                Active = true,
                EducationItems = request.EducationRequestItems.Select(i => new EducationItem
                {
                    EducationItemID = Guid.NewGuid().ToString(),
                    EducationHeaderID = iD,
                    Education = i.Education,
                    Subject = i.Subject,
                    Institution = i.Institution,
                    StartYear = i.StartYear,
                    EndYear = i.EndYear,
                    Remark = i.Remark,
                    Attachment = i.Attachment,
                    CreatedUserID = "DFDB7579-F4DA-4334-BE84-0E57DF415560",
                    CreatedDate = DateTime.Now,
                    Active = true
                }).ToList()
            };

            _context.EducationHeader.Add(header);
            await _context.SaveChangesAsync();
            return new ServiceResponse(true, "Save Successful");
        }

        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var header = await _context.EducationHeader
            .Include(h => h.EducationItems)
            .FirstOrDefaultAsync(h => h.EducationHaderID == id);

            if (header == null) return new ServiceResponse(false, "Data not Found");

            _context.EducationHeader.Remove(header);
            await _context.SaveChangesAsync();
            return new ServiceResponse(true, "Delete Successful");
        }

        public async Task<List<EducationHeaderDto>> GetAllAsync()
        {
            var data = await _context.EducationHeader
                 .Include(e => e.Employee)
                 .Select(h => new EducationHeaderDto
                 {
                     EducationHaderID = h.EducationHaderID,
                     EmployeeID = h.EmployeeID,
                     EmployeeName = h.Employee.Name,
                     CreatedUserID = h.CreatedUserID,
                     CreatedDate = h.CreatedDate,
                     EducationItems = h.EducationItems.Select(i => new EducationItemDto
                     {
                         EducationItemID = i.EducationItemID,
                         EducationHeaderID = i.EducationHeaderID,
                         Education = i.Education,
                         Subject = i.Subject,
                         Institution = i.Institution,
                         StartYear = i.StartYear,
                         EndYear = i.EndYear,
                         Remark = i.Remark,
                         Attachment = i.Attachment,

                     }).ToList()
                 })
            .ToListAsync();

            return data;

        }

        public Task<EducationHeaderDto> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateAsync(string id, EducationRequest request)
        {
            throw new NotImplementedException();
        }     
    }
}
