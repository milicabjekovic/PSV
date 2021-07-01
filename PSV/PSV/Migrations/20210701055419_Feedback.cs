using Microsoft.EntityFrameworkCore.Migrations;

namespace PSV.Migrations
{
    public partial class Feedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientEmail",
                table: "Feedback",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientEmail",
                table: "Feedback");
        }
    }
}
