using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Data.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PupilsId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CoursePupil",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    PupilsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePupil", x => new { x.CoursesId, x.PupilsId });
                    table.ForeignKey(
                        name: "FK_CoursePupil_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePupil_Pupils_PupilsId",
                        column: x => x.PupilsId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursePupil_PupilsId",
                table: "CoursePupil",
                column: "PupilsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursePupil");

            migrationBuilder.DropColumn(
                name: "PupilsId",
                table: "Courses");
        }
    }
}
