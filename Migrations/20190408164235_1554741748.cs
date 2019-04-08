using Microsoft.EntityFrameworkCore.Migrations;

namespace Wings.Migrations
{
    public partial class _1554741748 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createTime3",
                table: "user",
                newName: "CreateTime4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateTime4",
                table: "user",
                newName: "createTime3");
        }
    }
}
