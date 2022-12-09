using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatBook.Migrations
{
    public partial class thirdsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "requests");

            migrationBuilder.AlterColumn<int>(
                name: "catId",
                table: "requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "catId",
                table: "requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
