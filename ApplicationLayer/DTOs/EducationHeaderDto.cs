
namespace ApplicationLayer.DTOs
{
    public class EducationHeaderDto : BaseDto
    {    
        public string EducationHaderID { get; set; }     
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public List<EducationItemDto> EducationItems { get; set; } = new();
    }
}
