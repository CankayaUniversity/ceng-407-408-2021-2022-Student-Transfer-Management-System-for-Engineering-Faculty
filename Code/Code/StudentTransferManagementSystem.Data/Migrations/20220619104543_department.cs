using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTransferManagementSystem.Data.Migrations
{
    public partial class department : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Students");
        }
    }
}
