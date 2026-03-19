using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Menu
    {
        [Key]
        [Column(TypeName = "char(36)")]
        public string MenuID { get; set; }
        public string MenuName { get; set; }
        public string? ControllerName { get; set; }

        public string? Url { get; set; }
        public string? Icon { get; set; }

        public string? ParentId { get; set; }

        public decimal SeniorOrderNo { get; set; }
    }
}
