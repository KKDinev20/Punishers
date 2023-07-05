using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("languages")]
public partial class Language
{
    [Key]
    public int Id { get; set; }

    [StringLength(45)]
    public string LanguageName { get; set; } = null!;

    [StringLength(45)]
    public string ProficiencyLevel { get; set; } = null!;

    [ForeignKey("LanguageId")]
    [InverseProperty("Languages")]
    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();
}
