using System;
using System.Collections.Generic;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace DataAccessLayer.Data;

public partial class AibestdbContext : DbContext
{
    public AibestdbContext()
    {
    }

    public AibestdbContext(DbContextOptions<AibestdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Personalinfo> Personalinfos { get; set; }

    public virtual DbSet<Resume> Resumes { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Template> Templates { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Workexperience> Workexperiences { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=Dun62986!;database=AIBESTDB");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Dictionary<string, string> envValues = EnvReader.Read("../../../../connection.env");

        optionsBuilder.UseMySQL(
            $"server={envValues["SERVER"]};" +
            $"uid={envValues["UID"]};" +
            $"pwd={envValues["PWD"]};" +
            $"database={envValues["DATABASE"]}"
            );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Resume).WithMany(p => p.Certificates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CertResumeId");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Resume).WithMany(p => p.Educations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EduResumeId");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Personalinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Resume).WithMany(p => p.Personalinfos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PersonalInfoResumeId");
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.User).WithMany(p => p.Resumes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserId");

            entity.HasMany(d => d.Languages).WithMany(p => p.Resumes)
                .UsingEntity<Dictionary<string, object>>(
                    "Resumeslanguage",
                    r => r.HasOne<Language>().WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("LanguageId"),
                    l => l.HasOne<Resume>().WithMany()
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("LangResumeId"),
                    j =>
                    {
                        j.HasKey("ResumeId", "LanguageId").HasName("PRIMARY");
                        j.ToTable("resumeslanguages");
                        j.HasIndex(new[] { "LanguageId" }, "LanguageId_idx");
                    });

            entity.HasMany(d => d.Locations).WithMany(p => p.Resumes)
                .UsingEntity<Dictionary<string, object>>(
                    "Resumeslocation",
                    r => r.HasOne<Location>().WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("LocationId"),
                    l => l.HasOne<Resume>().WithMany()
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("LocationResumeId"),
                    j =>
                    {
                        j.HasKey("ResumeId", "LocationId").HasName("PRIMARY");
                        j.ToTable("resumeslocations");
                        j.HasIndex(new[] { "LocationId" }, "LocationId_idx");
                    });

            entity.HasMany(d => d.Skills).WithMany(p => p.Resumes)
                .UsingEntity<Dictionary<string, object>>(
                    "Resumesskill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("SkillId"),
                    l => l.HasOne<Resume>().WithMany()
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("SkillResumeId"),
                    j =>
                    {
                        j.HasKey("ResumeId", "SkillId").HasName("PRIMARY");
                        j.ToTable("resumesskills");
                        j.HasIndex(new[] { "SkillId" }, "SkillId_idx");
                    });

            entity.HasMany(d => d.Templates).WithMany(p => p.Resumes)
                .UsingEntity<Dictionary<string, object>>(
                    "Resumestemplate",
                    r => r.HasOne<Template>().WithMany()
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("TemplateId"),
                    l => l.HasOne<Resume>().WithMany()
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("TemplateResumeId"),
                    j =>
                    {
                        j.HasKey("ResumeId", "TemplateId").HasName("PRIMARY");
                        j.ToTable("resumestemplates");
                        j.HasIndex(new[] { "TemplateId" }, "TemplateId_idx");
                    });
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Workexperience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Resume).WithMany(p => p.Workexperiences)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("WorkResumeId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
