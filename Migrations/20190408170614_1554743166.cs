using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wings.Migrations
{
    public partial class _1554743166 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "user",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "user",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "orderNoid",
                table: "user",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "order_no",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_no", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_orderNoid",
                table: "user",
                column: "orderNoid");

            migrationBuilder.AddForeignKey(
                name: "FK_user_order_no_orderNoid",
                table: "user",
                column: "orderNoid",
                principalTable: "order_no",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_order_no_orderNoid",
                table: "user");

            migrationBuilder.DropTable(
                name: "order_no");

            migrationBuilder.DropIndex(
                name: "IX_user_orderNoid",
                table: "user");

            migrationBuilder.DropColumn(
                name: "orderNoid",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "user",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
