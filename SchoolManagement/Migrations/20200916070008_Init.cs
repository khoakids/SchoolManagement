using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDay = table.Column<DateTime>(type: "date", nullable: true),
                    FinishDay = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__C92D71A798C7CD5F", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    MajorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajorName = table.Column<string>(maxLength: 100, nullable: true),
                    FoundedYear = table.Column<int>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Majors__D5B8BF91E864AD82", x => x.MajorId);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    ProgramId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Programs__7525605804CB3EE2", x => x.ProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajorId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Classes__CB1927C03F14F819", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK__Classes__CourseI__2B3F6F97",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Classes__MajorId__2A4B4B5E",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "MajorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajorId = table.Column<int>(nullable: false),
                    SubjectName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subjects__AC1BA3A8DAB31507", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK__Subjects__Subjec__30F848ED",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "MajorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(maxLength: 100, nullable: true),
                    BirthDay = table.Column<DateTime>(type: "date", nullable: true),
                    ClassId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Students__32C52B999360B586", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK__Students__ClassI__2E1BDC42",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfomationSubjects",
                columns: table => new
                {
                    ProgramId = table.Column<int>(nullable: false),
                    MajorId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    StudyYear = table.Column<int>(nullable: false),
                    Semester = table.Column<int>(nullable: true),
                    TheoreticalHour = table.Column<int>(nullable: true),
                    PraticeHour = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Infomati__D9F90FD2679F151F", x => new { x.ProgramId, x.MajorId, x.SubjectId, x.StudyYear });
                    table.ForeignKey(
                        name: "FK__Infomatio__Major__38996AB5",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "MajorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Infomatio__Progr__37A5467C",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Infomatio__Subje__398D8EEE",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    ExamTime = table.Column<int>(nullable: false),
                    TestScore = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Results__0800C6081B50451D", x => new { x.StudentId, x.SubjectId, x.ExamTime });
                    table.ForeignKey(
                        name: "FK__Results__Student__33D4B598",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Results__Subject__34C8D9D1",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CourseId",
                table: "Classes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_MajorId",
                table: "Classes",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_InfomationSubjects_MajorId",
                table: "InfomationSubjects",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_InfomationSubjects_SubjectId",
                table: "InfomationSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_SubjectId",
                table: "Results",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_MajorId",
                table: "Subjects",
                column: "MajorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfomationSubjects");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Majors");
        }
    }
}
