using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

[Table("users")]
[Index("Email", Name = "Email_UNIQUE", IsUnique = true)]
[Index("Username", Name = "Username_UNIQUE", IsUnique = true)]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(24)]
    public string Username { get; set; } = null!;

    [StringLength(64)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string Password { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Resume> Resumes { get; set; } = new List<Resume>();

    public User(int id, string username, string email, string password)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
    }
}
