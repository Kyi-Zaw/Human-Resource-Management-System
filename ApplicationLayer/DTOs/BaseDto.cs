using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs
{
    public class BaseDto
    {
        public bool Active { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedUserID { get; set; }

        public string? CreatedUser { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedUserID { get; set; }

        public string? UpdatedUser { get; set; }

    }
}
