using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("templates")]
public partial class Template
{
    [Key]
    public int Id { get; set; }

    [StringLength(45)]
    public string TemplateName { get; set; } = null!;

    [StringLength(1024)]
    public string TemplateFilePath { get; set; } = null!;

    [ForeignKey("TemplateId")]
    [InverseProperty("Templates")]
    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();
}
