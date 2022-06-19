using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTransferManagementSystem.Data.Migrations
{
    public partial class DepartmentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentCode",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentCode",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
