using Microsoft.EntityFrameworkCore.Migrations;

namespace Cv_Generator_Server.Migrations
{
    public partial class AddStateToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "references",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "profesional_Infos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "experience_Works",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "detailUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "contacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "academics",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "skills");

            migrationBuilder.DropColumn(
                name: "State",
                table: "references");

            migrationBuilder.DropColumn(
                name: "State",
                table: "profesional_Infos");

            migrationBuilder.DropColumn(
                name: "State",
                table: "experience_Works");

            migrationBuilder.DropColumn(
                name: "State",
                table: "detailUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "State",
                table: "academics");
        }
    }
}
