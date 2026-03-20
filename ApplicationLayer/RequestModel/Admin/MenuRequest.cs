using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.RequestModel.Admin
{
    public class MenuRequest
    {

        [Required(ErrorMessage = "MenuName is required")]
        public string MenuName { get; set; }

        public string? ControllerName { get; set; }

        public string? Url { get; set; }

        public string? Icon { get; set; }

        public int OrderNo { get; set; }

        public string? Parent { get; set; }

    }
}
