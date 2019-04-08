using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wings.Migrations
{
    public partial class date04date52date820time11time32time62 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createTime",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "inputTime",
                table: "user",
                newName: "createTime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createTime2",
                table: "user",
                newName: "inputTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "createTime",
                table: "user",
                type: "datetime",
                nullable: true);
        }
    }
}
