using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class PostInfo : BaseEntity
    {
        [Key]
        [Column(TypeName = "char(36)")]
        public string PostID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
