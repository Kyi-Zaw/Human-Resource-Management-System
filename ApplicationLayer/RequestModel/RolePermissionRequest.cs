using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.RequestModel
{
    public class RolePermissionRequest
    {
        [Required(ErrorMessage = "RoleName is required")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "ControllerName is required")]
        public string ControllerName { get; set; }

        [Required(ErrorMessage = "MenuName is required")]
        public string MenuName { get; set; }

        [Required(ErrorMessage = "Url is required")]
        public string Url { get; set; }

        public string Icon { get; set; }

        public int OrderNo { get; set; }

        public string Parent { get; set; }

        [Required(ErrorMessage = "IsAllowed is required")]
        public bool IsAllowed { get; set; }
    }
}
