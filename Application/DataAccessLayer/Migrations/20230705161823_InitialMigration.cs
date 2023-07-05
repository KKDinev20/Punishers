using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LanguageResume",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    ResumeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageResume", x => new { x.LanguageId, x.ResumeId });
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LanguageName = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    ProficiencyLevel = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LocationResume",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ResumeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationResume", x => new { x.LocationId, x.ResumeId });
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    State = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Country = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ResumeSkill",
                columns: table => new
                {
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSkill", x => new { x.ResumeId, x.SkillId });
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ResumeTemplate",
                columns: table => new
                {
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeTemplate", x => new { x.ResumeId, x.TemplateId });
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SkillName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "templates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TemplateName = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    TemplateFilePath = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(24)", maxLength: 24, nullable: false),
                    Email = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "varchar(24)", maxLength: 24, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "resumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    CertificateName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    IssuingOrganization = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "CertResumeId",
                        column: x => x.ResumeId,
                        principalTable: "resumes",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    InstituteName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Degree = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    FieldOfStudy = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "EduResumeId",
                        column: x => x.ResumeId,
                        principalTable: "resumes",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personalinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Address = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "PersonalInfoResumeId",
                        column: x => x.ResumeId,
                        principalTable: "resumes",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "resumeslanguages",
                columns: table => new
                {
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.ResumeId, x.LanguageId });
                    table.ForeignKey(
                        name: "LangResumeId",
                        column: x => x.ResumeId,
                        principalTable: "resumes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "languages",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "resumeslocations",
                columns: table => new
                {
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.ResumeId, x.LocationId });
                    table.ForeignKey(
                        name: "LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "LocationResumeId",
                        column: x => x.ResumeId,
                        principalTable: "resumes",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "resumesskills",
                columns: table => new
                {
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.ResumeId, x.SkillId });
                    table.ForeignKey(
                        name: "SkillId",
                        column: x => x.SkillId,
                        principalTable: "skills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "SkillResumeId",
                        column: x => x.ResumeId,
                        principalTable: "resumes",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "resumestemplates",
                columns: table => new
                {
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.ResumeId, x.TemplateId });
                    table.ForeignKey(
                        name: "TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "templates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "TemplateResumeId",
                        column: x => x.ResumeId,
                        principalTable: "resumes",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "workexperience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ResumeId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Position = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Description = table.Column<byte[]>(type: "blob", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "WorkResumeId",
                        column: x => x.ResumeId,
                        principalTable: "resumes",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ResumeId_idx",
                table: "certificates",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "ResumeId_idx1",
                table: "education",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "ResumeId_idx2",
                table: "personalinfo",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "UserId_idx",
                table: "resumes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "LanguageId_idx",
                table: "resumeslanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "LocationId_idx",
                table: "resumeslocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "SkillId_idx",
                table: "resumesskills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "TemplateId_idx",
                table: "resumestemplates",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "Email_UNIQUE",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Username_UNIQUE",
                table: "users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ResumeId_idx3",
                table: "workexperience",
                column: "ResumeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "certificates");

            migrationBuilder.DropTable(
                name: "education");

            migrationBuilder.DropTable(
                name: "LanguageResume");

            migrationBuilder.DropTable(
                name: "LocationResume");

            migrationBuilder.DropTable(
                name: "personalinfo");

            migrationBuilder.DropTable(
                name: "ResumeSkill");

            migrationBuilder.DropTable(
                name: "resumeslanguages");

            migrationBuilder.DropTable(
                name: "resumeslocations");

            migrationBuilder.DropTable(
                name: "resumesskills");

            migrationBuilder.DropTable(
                name: "resumestemplates");

            migrationBuilder.DropTable(
                name: "ResumeTemplate");

            migrationBuilder.DropTable(
                name: "workexperience");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "templates");

            migrationBuilder.DropTable(
                name: "resumes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
