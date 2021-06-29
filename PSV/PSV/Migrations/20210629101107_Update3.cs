using Microsoft.EntityFrameworkCore.Migrations;

namespace PSV.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Examinations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "BusinessHours",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_DoctorId",
                table: "Examinations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessHours_DoctorId",
                table: "BusinessHours",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessHours_Users_DoctorId",
                table: "BusinessHours",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Users_DoctorId",
                table: "Examinations",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessHours_Users_DoctorId",
                table: "BusinessHours");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Users_DoctorId",
                table: "Examinations");

            migrationBuilder.DropIndex(
                name: "IX_Examinations_DoctorId",
                table: "Examinations");

            migrationBuilder.DropIndex(
                name: "IX_BusinessHours_DoctorId",
                table: "BusinessHours");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "BusinessHours");
        }
    }
}
