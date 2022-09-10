using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoDbMigrations.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "myapp");

            migrationBuilder.CreateTable(
                name: "students",
                schema: "myapp",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                schema: "myapp",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "student_subjects",
                schema: "myapp",
                columns: table => new
                {
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subject_id = table.Column<Guid>(type: "uuid", nullable: false),
                    mark = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_subjects", x => new { x.student_id, x.subject_id });
                    table.ForeignKey(
                        name: "FK_student_subjects_students_student_id",
                        column: x => x.student_id,
                        principalSchema: "myapp",
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_subjects_subjects_subject_id",
                        column: x => x.subject_id,
                        principalSchema: "myapp",
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_subjects_subject_id",
                schema: "myapp",
                table: "student_subjects",
                column: "subject_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student_subjects",
                schema: "myapp");

            migrationBuilder.DropTable(
                name: "students",
                schema: "myapp");

            migrationBuilder.DropTable(
                name: "subjects",
                schema: "myapp");
        }
    }
}
