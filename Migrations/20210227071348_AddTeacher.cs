using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWepAPI.Migrations
{
    public partial class AddTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addSubjects",
                columns: table => new
                {
                    Subject_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_Name = table.Column<string>(type: "varchar(250)", nullable: true),
                    Subject_Level = table.Column<string>(type: "varchar(250)", nullable: true),
                    Subject_CreateBy = table.Column<int>(type: "int", nullable: false),
                    Subject_CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addSubjects", x => x.Subject_ID);
                });

            migrationBuilder.CreateTable(
                name: "addTeacherDetails",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_FirstName = table.Column<string>(type: "varchar(250)", nullable: true),
                    Teacher_LastName = table.Column<string>(type: "varchar(250)", nullable: true),
                    Teacher_PhoneNo = table.Column<long>(type: "bigint", nullable: false),
                    Teacher_Email = table.Column<string>(type: "varchar(250)", nullable: false),
                    Teacher_AssignClass = table.Column<string>(type: "varchar(250)", nullable: true),
                    Teacher_ClassTeacher = table.Column<int>(type: "int", nullable: false),
                    Teacher_Education = table.Column<string>(type: "varchar(250)", nullable: true),
                    Teacher_Address = table.Column<string>(type: "varchar(250)", nullable: true),
                    Teacher_SubjectTeacher = table.Column<string>(type: "varchar(250)", nullable: true),
                    Teacher_ImageName = table.Column<string>(type: "varchar(250)", nullable: true),
                    Teacher_SignatureName = table.Column<string>(type: "varchar(250)", nullable: true),
                    Teacher_CreateBy = table.Column<int>(type: "int", nullable: false),
                    Teacher_CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addTeacherDetails", x => x.TeacherId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addSubjects");

            migrationBuilder.DropTable(
                name: "addTeacherDetails");
        }
    }
}
