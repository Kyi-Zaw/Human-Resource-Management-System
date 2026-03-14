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

        [Required(ErrorMessage = "IsAllowed is required")]
        public bool IsAllowed { get; set; }
    }
}
