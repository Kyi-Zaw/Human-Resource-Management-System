

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities;

public class Employee : BaseEntity
{
    [Key]
    [Column(TypeName = "char(36)")]
    public string EmployeeID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}
