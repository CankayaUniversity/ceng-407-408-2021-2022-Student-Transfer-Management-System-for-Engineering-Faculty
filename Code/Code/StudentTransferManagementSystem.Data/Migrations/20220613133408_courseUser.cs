using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTransferManagementSystem.Data.Migrations
{
    public partial class courseUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DepartmentCode",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentCode",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentCode",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentCode",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
