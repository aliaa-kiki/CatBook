using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatBook.Migrations
{
    public partial class thirdsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cat",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    about = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    originalUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vaccinated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    neutered = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vaccinationbook = table.Column<int>(type: "int", nullable: false),
                    newUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat", x => x.id);
                    table.ForeignKey(
                        name: "FK_cat_AspNetUsers_newUserId",
                        column: x => x.newUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_cat_AspNetUsers_originalUserId",
                        column: x => x.originalUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cat_newUserId",
                table: "cat",
                column: "newUserId");

            migrationBuilder.CreateIndex(
                name: "IX_cat_originalUserId",
                table: "cat",
                column: "originalUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cat");
        }
    }
}
