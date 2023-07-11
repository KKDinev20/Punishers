using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("resumes")]
[Index("UserId", Name = "UserId_idx")]
public partial class Resume
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [StringLength(64)]
    public string Title { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime LastModifiedDate { get; set; }

    [InverseProperty("Resume")]
    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    [InverseProperty("Resume")]
    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    [InverseProperty("Resume")]
    public virtual ICollection<Personalinfo> Personalinfos { get; set; } = new List<Personalinfo>();

    [ForeignKey("UserId")]
    [InverseProperty("Resumes")]
    public virtual User? User { get; set; } = null;

    [InverseProperty("Resume")]
    public virtual ICollection<Workexperience> Workexperiences { get; set; } = new List<Workexperience>();

    [ForeignKey("ResumeId")]
    [InverseProperty("Resumes")]
    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();

    [ForeignKey("ResumeId")]
    [InverseProperty("Resumes")]
    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    [ForeignKey("ResumeId")]
    [InverseProperty("Resumes")]
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    [ForeignKey("ResumeId")]
    [InverseProperty("Resumes")]
    public virtual ICollection<Template> Templates { get; set; } = new List<Template>();
}
