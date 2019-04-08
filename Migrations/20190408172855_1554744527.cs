using Microsoft.EntityFrameworkCore.Migrations;

namespace Wings.Migrations
{
    public partial class _1554744527 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "user",
                newName: "Id");
        }
    }
}
