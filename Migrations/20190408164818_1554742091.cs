using Microsoft.EntityFrameworkCore.Migrations;

namespace Wings.Migrations
{
    public partial class _1554742091 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateTime5",
                table: "user",
                newName: "createTime5");

            migrationBuilder.RenameColumn(
                name: "CreateTime4",
                table: "user",
                newName: "createTime4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createTime5",
                table: "user",
                newName: "CreateTime5");

            migrationBuilder.RenameColumn(
                name: "createTime4",
                table: "user",
                newName: "CreateTime4");
        }
    }
}
