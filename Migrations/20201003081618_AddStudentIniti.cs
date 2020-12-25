using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWepAPI.Migrations
{
    public partial class AddStudentIniti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addStudentDetails",
                columns: table => new
                {
                    ASD_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ASD_FirstName = table.Column<string>(type: "varchar(200)", nullable: false),
                    ASD_LastName = table.Column<string>(type: "varchar(250)", nullable: false),
                    ASD_FatherName = table.Column<string>(type: "varchar(250)", nullable: false),
                    ASD_MotherName = table.Column<string>(type: "varchar(250)", nullable: false),
                    ASD_PhoneNo = table.Column<long>(type: "bigint", nullable: false),
                    ASD_EmailId = table.Column<string>(type: "varchar(250)", nullable: true),
                    ASD_AadharNo = table.Column<long>(type: "bigint", nullable: false),
                    ASD_DOB = table.Column<DateTime>(type: "datetime", nullable: false),
                    ASD_State = table.Column<int>(type: "int", nullable: false),
                    ASD_Distric = table.Column<int>(type: "int", nullable: false),
                    ASD_Category = table.Column<int>(type: "int", nullable: false),
                    ASD_StudentClass = table.Column<int>(type: "int", nullable: false),
                    ASD_DOJ = table.Column<DateTime>(type: "datetime", nullable: false),
                    ASD_gender = table.Column<int>(type: "int", nullable: false),
                    ASD_PrincipalName = table.Column<string>(type: "varchar(200)", nullable: true),
                    ASD_TeacherName = table.Column<string>(type: "varchar(200)", nullable: true),
                    ASD_Leaving_Status = table.Column<int>(type: "int", nullable: false),
                    ASD_PermanentAddress = table.Column<string>(type: "varchar(250)", nullable: true),
                    ASD_TemporaryAddress = table.Column<string>(type: "varchar(250)", nullable: true),
                    ASD_ImageName = table.Column<string>(type: "varchar(250)", nullable: true),
                    ASD_SignatureName = table.Column<string>(type: "varchar(250)", nullable: true),
                    ASD_CreateBy = table.Column<int>(type: "int", nullable: false),
                    ASD_CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addStudentDetails", x => x.ASD_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addStudentDetails");
        }
    }
}
