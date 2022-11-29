using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatBook.Migrations
{
    public partial class secondsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cats_CatBookUser_userId",
                table: "cats");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "cats",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_cats_CatBookUser_userId",
                table: "cats",
                column: "userId",
                principalTable: "CatBookUser",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cats_CatBookUser_userId",
                table: "cats");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "cats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cats_CatBookUser_userId",
                table: "cats",
                column: "userId",
                principalTable: "CatBookUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
