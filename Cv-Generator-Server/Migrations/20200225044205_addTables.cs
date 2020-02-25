using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cv_Generator_Server.Migrations
{
    public partial class addTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "academics",
                columns: table => new
                {
                    AcademicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Institution = table.Column<string>(maxLength: 50, nullable: false),
                    Degree = table.Column<string>(maxLength: 25, nullable: false),
                    Start_Date = table.Column<DateTime>(nullable: false),
                    End_Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academics", x => x.AcademicId);
                    table.ForeignKey(
                        name: "FK_academics_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 20, nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_contacts_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailUsers",
                columns: table => new
                {
                    DetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(nullable: true),
                    Second_Name = table.Column<string>(maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Nit = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailUsers", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_detailUsers_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "experience_Works",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(maxLength: 60, nullable: false),
                    Start_Date = table.Column<DateTime>(nullable: false),
                    End_Date = table.Column<DateTime>(nullable: false),
                    Rol = table.Column<string>(maxLength: 30, nullable: false),
                    Rol_Description = table.Column<string>(maxLength: 255, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experience_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_experience_Works_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profesional_Infos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profesion = table.Column<string>(maxLength: 25, nullable: false),
                    Experience = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(maxLength: 100, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesional_Infos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profesional_Infos_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "references",
                columns: table => new
                {
                    ReferenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Phone = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_references", x => x.ReferenceId);
                    table.ForeignKey(
                        name: "FK_references_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    SkillsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 35, nullable: false),
                    Percent = table.Column<int>(nullable: false),
                    Profesional_InfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.SkillsId);
                    table.ForeignKey(
                        name: "FK_skills_profesional_Infos_Profesional_InfoId",
                        column: x => x.Profesional_InfoId,
                        principalTable: "profesional_Infos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_academics_UserId",
                table: "academics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_UserId",
                table: "contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_detailUsers_UserId",
                table: "detailUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_experience_Works_UserId",
                table: "experience_Works",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_profesional_Infos_UserId",
                table: "profesional_Infos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_references_UserId",
                table: "references",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_skills_Profesional_InfoId",
                table: "skills",
                column: "Profesional_InfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "academics");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "detailUsers");

            migrationBuilder.DropTable(
                name: "experience_Works");

            migrationBuilder.DropTable(
                name: "references");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "profesional_Infos");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
