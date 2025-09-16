using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class EducationItem : BaseEntity
    {
        [Key]  
        public string EducationItemID { get; set; }

        [ForeignKey("EducationHeader")]  
        public string EducationHeaderID { get; set; }
        public string Education { get; set; }
        public string Subject { get; set; }
        public string Institution { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Remark { get; set; }
        public string Attachment { get; set; }
        public EducationHeader EducationHeader { get; set; }
    }
}
