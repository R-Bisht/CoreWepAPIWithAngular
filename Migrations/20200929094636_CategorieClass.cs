using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWepAPI.Migrations
{
    public partial class CategorieClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CTG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CTG_NAME = table.Column<string>(type: "varchar(250)", nullable: true),
                    CTG_CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    CTG_CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CTG);
                });

            migrationBuilder.CreateTable(
                name: "studentClasses",
                columns: table => new
                {
                    STC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STC_NAME = table.Column<string>(type: "varchar(250)", nullable: false),
                    STC_CREATED_BY = table.Column<int>(type: "int", nullable: false),
                    STC_CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentClasses", x => x.STC);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "studentClasses");
        }
    }
}
