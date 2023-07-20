using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurriculumVitaeAPI.Migrations
{
    public partial class addSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Resumes");
        }
    }
}
