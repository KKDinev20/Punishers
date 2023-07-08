﻿// <auto-generated />
using System;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(AibestdbContext))]
    partial class AibestdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataAccessLayer.Models.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CertificateName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("date");

                    b.Property<string>("IssuingOrganization")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ResumeId" }, "ResumeId_idx");

                    b.ToTable("certificates");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("FieldOfStudy")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("InstituteName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ResumeId" }, "ResumeId_idx")
                        .HasDatabaseName("ResumeId_idx1");

                    b.ToTable("education");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("ProficiencyLevel")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("languages");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Personalinfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ResumeId" }, "ResumeId_idx")
                        .HasDatabaseName("ResumeId_idx2");

                    b.ToTable("personalinfo");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Resume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserId" }, "UserId_idx");

                    b.ToTable("resumes");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("skills");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TemplateFilePath")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("TemplateName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("templates");
                });

            modelBuilder.Entity("DataAccessLayer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("varchar(24)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Email" }, "Email_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "Username_UNIQUE")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Workexperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<byte[]>("Description")
                        .IsRequired()
                        .HasColumnType("blob");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ResumeId" }, "ResumeId_idx")
                        .HasDatabaseName("ResumeId_idx3");

                    b.ToTable("workexperience");
                });

            modelBuilder.Entity("LanguageResume", b =>
                {
                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.HasKey("LanguageId", "ResumeId");

                    b.ToTable("LanguageResume");
                });

            modelBuilder.Entity("LocationResume", b =>
                {
                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.HasKey("LocationId", "ResumeId");

                    b.ToTable("LocationResume");
                });

            modelBuilder.Entity("ResumeSkill", b =>
                {
                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("ResumeId", "SkillId");

                    b.ToTable("ResumeSkill");
                });

            modelBuilder.Entity("ResumeTemplate", b =>
                {
                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("ResumeId", "TemplateId");

                    b.ToTable("ResumeTemplate");
                });

            modelBuilder.Entity("Resumeslanguage", b =>
                {
                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("ResumeId", "LanguageId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "LanguageId" }, "LanguageId_idx");

                    b.ToTable("resumeslanguages", (string)null);
                });

            modelBuilder.Entity("Resumeslocation", b =>
                {
                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("ResumeId", "LocationId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "LocationId" }, "LocationId_idx");

                    b.ToTable("resumeslocations", (string)null);
                });

            modelBuilder.Entity("Resumesskill", b =>
                {
                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("ResumeId", "SkillId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "SkillId" }, "SkillId_idx");

                    b.ToTable("resumesskills", (string)null);
                });

            modelBuilder.Entity("Resumestemplate", b =>
                {
                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("ResumeId", "TemplateId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "TemplateId" }, "TemplateId_idx");

                    b.ToTable("resumestemplates", (string)null);
                });

            modelBuilder.Entity("DataAccessLayer.Models.Certificate", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Resume", "Resume")
                        .WithMany("Certificates")
                        .HasForeignKey("ResumeId")
                        .IsRequired()
                        .HasConstraintName("CertResumeId");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Education", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Resume", "Resume")
                        .WithMany("Educations")
                        .HasForeignKey("ResumeId")
                        .IsRequired()
                        .HasConstraintName("EduResumeId");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Personalinfo", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Resume", "Resume")
                        .WithMany("Personalinfos")
                        .HasForeignKey("ResumeId")
                        .IsRequired()
                        .HasConstraintName("PersonalInfoResumeId");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Resume", b =>
                {
                    b.HasOne("DataAccessLayer.Models.User", "User")
                        .WithMany("Resumes")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Workexperience", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Resume", "Resume")
                        .WithMany("Workexperiences")
                        .HasForeignKey("ResumeId")
                        .IsRequired()
                        .HasConstraintName("WorkResumeId");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("Resumeslanguage", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .IsRequired()
                        .HasConstraintName("LanguageId");

                    b.HasOne("DataAccessLayer.Models.Resume", null)
                        .WithMany()
                        .HasForeignKey("ResumeId")
                        .IsRequired()
                        .HasConstraintName("LangResumeId");
                });

            modelBuilder.Entity("Resumeslocation", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Location", null)
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .IsRequired()
                        .HasConstraintName("LocationId");

                    b.HasOne("DataAccessLayer.Models.Resume", null)
                        .WithMany()
                        .HasForeignKey("ResumeId")
                        .IsRequired()
                        .HasConstraintName("LocationResumeId");
                });

            modelBuilder.Entity("Resumesskill", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Resume", null)
                        .WithMany()
                        .HasForeignKey("ResumeId")
                        .IsRequired()
                        .HasConstraintName("SkillResumeId");

                    b.HasOne("DataAccessLayer.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .IsRequired()
                        .HasConstraintName("SkillId");
                });

            modelBuilder.Entity("Resumestemplate", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Resume", null)
                        .WithMany()
                        .HasForeignKey("ResumeId")
                        .IsRequired()
                        .HasConstraintName("TemplateResumeId");

                    b.HasOne("DataAccessLayer.Models.Template", null)
                        .WithMany()
                        .HasForeignKey("TemplateId")
                        .IsRequired()
                        .HasConstraintName("TemplateId");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Resume", b =>
                {
                    b.Navigation("Certificates");

                    b.Navigation("Educations");

                    b.Navigation("Personalinfos");

                    b.Navigation("Workexperiences");
                });

            modelBuilder.Entity("DataAccessLayer.Models.User", b =>
                {
                    b.Navigation("Resumes");
                });
#pragma warning restore 612, 618
        }
    }
}
