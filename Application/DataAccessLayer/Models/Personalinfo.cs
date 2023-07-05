using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("personalinfo")]
[Index("ResumeId", Name = "ResumeId_idx")]
public partial class Personalinfo
{
    [Key]
    public int Id { get; set; }

    public int ResumeId { get; set; }

    [StringLength(64)]
    public string FullName { get; set; } = null!;

    [StringLength(64)]
    public string Address { get; set; } = null!;

    [StringLength(16)]
    public string PhoneNumber { get; set; } = null!;

    [ForeignKey("ResumeId")]
    [InverseProperty("Personalinfos")]
    public virtual Resume Resume { get; set; } = null!;
}
