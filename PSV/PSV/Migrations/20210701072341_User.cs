using Microsoft.EntityFrameworkCore.Migrations;

namespace PSV.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChoosenDoctorId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFirstTime",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChoosenDoctorId",
                table: "Users",
                column: "ChoosenDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ChoosenDoctorId",
                table: "Users",
                column: "ChoosenDoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ChoosenDoctorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ChoosenDoctorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ChoosenDoctorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsFirstTime",
                table: "Users");
        }
    }
}
