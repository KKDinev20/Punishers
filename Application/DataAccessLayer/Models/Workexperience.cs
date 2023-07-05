using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("workexperience")]
[Index("ResumeId", Name = "ResumeId_idx")]
public partial class Workexperience
{
    [Key]
    public int Id { get; set; }

    public int ResumeId { get; set; }

    [StringLength(64)]
    public string CompanyName { get; set; } = null!;

    [StringLength(64)]
    public string Position { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }

    [Column(TypeName = "blob")]
    public byte[] Description { get; set; } = null!;

    [ForeignKey("ResumeId")]
    [InverseProperty("Workexperiences")]
    public virtual Resume Resume { get; set; } = null!;
}
