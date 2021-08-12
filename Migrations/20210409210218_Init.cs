using Microsoft.EntityFrameworkCore.Migrations;

namespace cv8_mvc.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CourseNameAbbreviation = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "CourseStatutes",
                columns: table => new
                {
                    CourseStatuteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStatutes", x => x.CourseStatuteId);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonalNumber = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 8, nullable: true),
                    StudyProgramName = table.Column<string>(type: "TEXT", nullable: true),
                    Faculty = table.Column<string>(type: "TEXT", nullable: true),
                    StudyProgramCode = table.Column<string>(type: "TEXT", nullable: true),
                    StudyForm = table.Column<string>(type: "TEXT", maxLength: 1, nullable: true),
                    YearOfStudy = table.Column<int>(type: "INTEGER", nullable: false),
                    Specialization = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    CardNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseStatuteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_CourseStatutes_CourseStatuteId",
                        column: x => x.CourseStatuteId,
                        principalTable: "CourseStatutes",
                        principalColumn: "CourseStatuteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CourseStatutes",
                columns: new[] { "CourseStatuteId", "Value" },
                values: new object[] { 1, "A" });

            migrationBuilder.InsertData(
                table: "CourseStatutes",
                columns: new[] { "CourseStatuteId", "Value" },
                values: new object[] { 2, "B" });

            migrationBuilder.InsertData(
                table: "CourseStatutes",
                columns: new[] { "CourseStatuteId", "Value" },
                values: new object[] { 3, "C" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "CourseNameAbbreviation", "Description" },
                values: new object[] { 1, null, "PAPR4", null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "CourseNameAbbreviation", "Description" },
                values: new object[] { 2, null, "DATA1", null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "CourseNameAbbreviation", "Description" },
                values: new object[] { 3, null, "OS1", null });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "Value" },
                values: new object[] { 1, "A" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "Value" },
                values: new object[] { 2, "B" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "Value" },
                values: new object[] { 3, "C" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "Value" },
                values: new object[] { 4, "D" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "Value" },
                values: new object[] { 5, "E" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "Value" },
                values: new object[] { 6, "F" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "CardNumber", "Email", "Faculty", "FirstName", "Gender", "LastName", "PersonalNumber", "Specialization", "StudyForm", "StudyProgramCode", "StudyProgramName", "UserName", "YearOfStudy" },
                values: new object[] { 1, "0C993347", "bercon00@prfnw.upol.cz", "PRF", "Ondřej", "M", "BERČÍK", "R19118", "INF", "P", "B0613A140009", "Informatika", "bercon00", 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "CardNumber", "Email", "Faculty", "FirstName", "Gender", "LastName", "PersonalNumber", "Specialization", "StudyForm", "StudyProgramCode", "StudyProgramName", "UserName", "YearOfStudy" },
                values: new object[] { 2, "AC0EBBE9", "bezdmi01@prfnw.upol.cz", "PRF", "Michal", "M", "BEZDĚK", "R19705", "APLINF", "P", "B0613A140008", "Aplikovaná informatika", "bezdmi01", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CourseStatutes");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
