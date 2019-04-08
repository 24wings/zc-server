using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wings.Migrations
{
    public partial class _1554744321 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "headImageid",
                table: "user",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OssFile",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OssFile", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_headImageid",
                table: "user",
                column: "headImageid");

            migrationBuilder.AddForeignKey(
                name: "FK_user_OssFile_headImageid",
                table: "user",
                column: "headImageid",
                principalTable: "OssFile",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_OssFile_headImageid",
                table: "user");

            migrationBuilder.DropTable(
                name: "OssFile");

            migrationBuilder.DropIndex(
                name: "IX_user_headImageid",
                table: "user");

            migrationBuilder.DropColumn(
                name: "headImageid",
                table: "user");
        }
    }
}
