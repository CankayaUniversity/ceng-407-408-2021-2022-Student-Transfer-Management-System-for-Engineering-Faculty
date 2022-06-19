using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTransferManagementSystem.Data.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModificationBy = table.Column<string>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Surname = table.Column<string>(maxLength: 60, nullable: false),
                    UniversityName = table.Column<string>(maxLength: 30, nullable: false),
                    FacultyName = table.Column<string>(maxLength: 30, nullable: false),
                    DepartmentName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
