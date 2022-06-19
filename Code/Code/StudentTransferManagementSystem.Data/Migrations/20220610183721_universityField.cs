using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTransferManagementSystem.Data.Migrations
{
    public partial class universityField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FacultyName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Universitry",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Universitry",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacultyName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
