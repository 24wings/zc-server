using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wings.Migrations
{
    public partial class _1554742053 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime5",
                table: "user",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime5",
                table: "user");
        }
    }
}
