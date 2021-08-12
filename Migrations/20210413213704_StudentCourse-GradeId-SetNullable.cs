using Microsoft.EntityFrameworkCore.Migrations;

namespace cv8_mvc.Migrations
{
    public partial class StudentCourseGradeIdSetNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Grades_GradeId",
                table: "StudentCourses");

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                table: "StudentCourses",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Grades_GradeId",
                table: "StudentCourses",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Grades_GradeId",
                table: "StudentCourses");

            migrationBuilder.AlterColumn<int>(
                name: "GradeId",
                table: "StudentCourses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Grades_GradeId",
                table: "StudentCourses",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
