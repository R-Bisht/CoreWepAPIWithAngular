using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreWepAPI.Migrations
{
    public partial class StateDistric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DST_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DST_DISTICT = table.Column<string>(type: "varchar(250)", nullable: false),
                    DST_STATEID = table.Column<int>(type: "int", nullable: false),
                    DST_CREATEDBY = table.Column<string>(type: "varchar(250)", nullable: true),
                    DST_CREATEDDATE = table.Column<DateTime>(type: "Datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DST_Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    STD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STD_NAME = table.Column<string>(type: "varchar(250)", nullable: false),
                    STD_CREATEDBY = table.Column<string>(type: "varchar(250)", nullable: true),
                    STD_CREATEDDATE = table.Column<DateTime>(type: "Datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.STD_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
