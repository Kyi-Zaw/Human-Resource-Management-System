using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs
{
    public class EducationItemDto
    {
        public string EducationItemID { get; set; }
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
