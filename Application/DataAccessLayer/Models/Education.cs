using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("education")]
[Index("ResumeId", Name = "ResumeId_idx")]
public partial class Education
{
    [Key]
    public int Id { get; set; }

    public int ResumeId { get; set; }

    [StringLength(128)]
    public string InstituteName { get; set; } = null!;

    [StringLength(128)]
    public string Degree { get; set; } = null!;

    [StringLength(64)]
    public string FieldOfStudy { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }

    [ForeignKey("ResumeId")]
    [InverseProperty("Educations")]
    public virtual Resume Resume { get; set; } = null!;
}
