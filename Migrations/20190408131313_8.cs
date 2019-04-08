using Microsoft.EntityFrameworkCore.Migrations;

namespace Wings.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "createTime2",
                table: "rbacUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createTime2",
                table: "rbacUsers");
        }
    }
}
