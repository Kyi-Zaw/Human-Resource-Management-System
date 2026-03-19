using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs
{
    public class MenuDto
    {
        public string MenuID { get; set; }
        public string ControllerName { get; set; }

        public string MenuName { get; set; }

        public string Url { get; set; }
        public string Icon { get; set; }
        public string? ParentId { get; set; }

        public decimal SeniorOrderNo { get; set; }

        public List<MenuDto> Children { get; set; } = new();
    }
}
