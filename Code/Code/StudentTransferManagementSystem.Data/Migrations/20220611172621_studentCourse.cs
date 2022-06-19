using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTransferManagementSystem.Data.Migrations
{
    public partial class studentCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModificationBy = table.Column<string>(nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    TakenCourseCode = table.Column<string>(nullable: true),
                    EquivalentCourseCode = table.Column<string>(nullable: true),
                    TakenCouseCredit = table.Column<string>(nullable: true),
                    EquivalentCourseCredit = table.Column<string>(nullable: true),
                    TakenCourseGrade = table.Column<string>(nullable: true),
                    EquivalentCourseGrade = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");
        }
    }
}
