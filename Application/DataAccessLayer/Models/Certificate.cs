using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("certificates")]
[Index("ResumeId", Name = "ResumeId_idx")]
public partial class Certificate
{
    [Key]
    public int Id { get; set; }

    public int ResumeId { get; set; }

    [StringLength(64)]
    public string CertificateName { get; set; } = null!;

    [StringLength(64)]
    public string IssuingOrganization { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime IssueDate { get; set; }

    [ForeignKey("ResumeId")]
    [InverseProperty("Certificates")]
    public virtual Resume Resume { get; set; } = null!;
}
