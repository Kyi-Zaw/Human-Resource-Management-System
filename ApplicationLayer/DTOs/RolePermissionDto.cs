using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs
{
    public class RolePermissionDto
    {
        public string RolePermissionID { get; set; }
        public string RoleName { get; set; }

        public string MenuID { get; set; }
        public bool IsAllowed { get; set; }

       
    }
}
