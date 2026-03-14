using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class RolePermissions
    {
        [Key]
        [Column(TypeName = "char(36)")]
        public string RolePermissionID { get; set; }
        public string RoleName { get; set; }
        public string ControllerName { get; set; }
        public bool IsAllowed { get; set; }
    }
}
