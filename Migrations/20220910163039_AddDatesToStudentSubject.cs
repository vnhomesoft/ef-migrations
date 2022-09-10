using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoDbMigrations.Migrations
{
    public partial class AddDatesToStudentSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "myapp",
                table: "student_subjects",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "last_modified_date",
                schema: "myapp",
                table: "student_subjects",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "myapp",
                table: "student_subjects");

            migrationBuilder.DropColumn(
                name: "last_modified_date",
                schema: "myapp",
                table: "student_subjects");
        }
    }
}
