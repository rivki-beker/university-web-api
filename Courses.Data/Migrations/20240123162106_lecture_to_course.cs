using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Data.Migrations
{
    public partial class lecture_to_course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LectureId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LectureId",
                table: "Courses",
                column: "LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lectures_LectureId",
                table: "Courses",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lectures_LectureId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LectureId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Courses");
        }
    }
}
