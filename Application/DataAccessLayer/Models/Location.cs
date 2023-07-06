using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("locations")]
public partial class Location
{
    [Key]
    public int Id { get; set; }

    [StringLength(64)]
    public string City { get; set; } = null!;

    [StringLength(64)]
    public string State { get; set; } = null!;

    [StringLength(64)]
    public string Country { get; set; } = null!;

    [ForeignKey("LocationId")]
    [InverseProperty("Locations")]
    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();
}
