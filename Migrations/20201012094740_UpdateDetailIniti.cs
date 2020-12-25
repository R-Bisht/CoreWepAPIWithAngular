using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWepAPI.Migrations
{
    public partial class UpdateDetailIniti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ASD_Application_Role",
                table: "addStudentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ASD_UserName",
                table: "addStudentDetails",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "applicationRoles",
                columns: table => new
                {
                    AR_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AR_ApplicationDiscriminator = table.Column<string>(type: "varchar(250)", nullable: true),
                    AR_CreateBy = table.Column<int>(type: "int", nullable: false),
                    AR_CreatedDate = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationRoles", x => x.AR_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applicationRoles");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ASD_Application_Role",
                table: "addStudentDetails");

            migrationBuilder.DropColumn(
                name: "ASD_UserName",
                table: "addStudentDetails");
        }
    }
}
