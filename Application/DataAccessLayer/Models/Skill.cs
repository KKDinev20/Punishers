using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("skills")]
public partial class Skill
{
    [Key]
    public int Id { get; set; }

    [StringLength(64)]
    public string SkillName { get; set; } = null!;

    [ForeignKey("SkillId")]
    [InverseProperty("Skills")]
    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();
}
