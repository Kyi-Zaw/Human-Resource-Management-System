using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class EducationHeader : BaseEntity
    {
        [Key]   
        public string EducationHaderID { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public string EmployeeID { get; set; }
        public List<EducationItem> EducationItems { get; set; } = new();
        public Employee Employee { get; set; }
    }
}
