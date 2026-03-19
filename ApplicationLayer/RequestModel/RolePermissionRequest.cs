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


        [Required(ErrorMessage = "MenuName is required")]
        public string MenuID { get; set; }

      
        public bool IsAllowed { get; set; }
    }
}
