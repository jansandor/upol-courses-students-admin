using Microsoft.EntityFrameworkCore.Migrations;

namespace cv8_mvc.Migrations
{
    public partial class ChangeOneToOneToOneToManyStudentCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_CourseStatuteId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_GradeId",
                table: "StudentCourses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseStatuteId",
                table: "StudentCourses",
                column: "CourseStatuteId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_GradeId",
                table: "StudentCourses",
                column: "GradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_CourseStatuteId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_GradeId",
                table: "StudentCourses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                columns: new[] { "StudentId", "CourseId", "CourseStatuteId", "GradeId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseStatuteId",
                table: "StudentCourses",
                column: "CourseStatuteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_GradeId",
                table: "StudentCourses",
                column: "GradeId",
                unique: true);
        }
    }
}
