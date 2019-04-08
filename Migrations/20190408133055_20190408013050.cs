using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wings.Migrations
{
    public partial class _20190408013050 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createTime2",
                table: "rbacUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "createTime",
                table: "rbacUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createTime",
                table: "rbacUsers");

            migrationBuilder.AddColumn<int>(
                name: "createTime2",
                table: "rbacUsers",
                nullable: true);
        }
    }
}
