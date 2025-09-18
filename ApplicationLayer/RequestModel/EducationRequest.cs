using ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.RequestModel
{
    public class EducationRequest
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public List<EducationItemRequest> EducationRequestItems { get; set; } = new();
    }

    public class EducationItemRequest
    {
        public string EducationHeaderID { get; set; }
        public string Education { get; set; }
        public string Subject { get; set; }
        public string Institution { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Remark { get; set; }
        public string Attachment { get; set; }
    }
}
