using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class BaseEntity
{
    public bool Active { get; set; } = true;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "char(36)")]
    public string CreatedUserID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [Column(TypeName = "char(36)")]
    public string? UpdatedUserID { get; set; }

    [Timestamp]   // Mark as concurrency token
    [Column(TypeName = "rowversion")]
    public byte[] TS { get; set; }
}