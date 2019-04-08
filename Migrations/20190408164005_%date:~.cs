using Microsoft.EntityFrameworkCore.Migrations;

namespace Wings.Migrations
{
    public partial class date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createTime2",
                table: "user",
                newName: "createTime3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createTime3",
                table: "user",
                newName: "createTime2");
        }
    }
}
