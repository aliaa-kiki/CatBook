using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatBook.Migrations
{
    public partial class firstsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatBookUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatBookUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "traits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_traits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    about = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vaccinated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    neutered = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vaccinationbook = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cats", x => x.id);
                    table.ForeignKey(
                        name: "FK_cats_CatBookUser_userId",
                        column: x => x.userId,
                        principalTable: "CatBookUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "catTraits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catId = table.Column<int>(type: "int", nullable: false),
                    traitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catTraits", x => x.id);
                    table.ForeignKey(
                        name: "FK_catTraits_cats_catId",
                        column: x => x.catId,
                        principalTable: "cats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_catTraits_traits_traitId",
                        column: x => x.traitId,
                        principalTable: "traits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "requests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    senderUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    catId = table.Column<int>(type: "int", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests", x => x.id);
                    table.ForeignKey(
                        name: "FK_requests_CatBookUser_senderUserId",
                        column: x => x.senderUserId,
                        principalTable: "CatBookUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requests_cats_catId",
                        column: x => x.catId,
                        principalTable: "cats",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cats_userId",
                table: "cats",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_catTraits_catId",
                table: "catTraits",
                column: "catId");

            migrationBuilder.CreateIndex(
                name: "IX_catTraits_traitId",
                table: "catTraits",
                column: "traitId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_catId",
                table: "requests",
                column: "catId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_senderUserId",
                table: "requests",
                column: "senderUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "catTraits");

            migrationBuilder.DropTable(
                name: "requests");

            migrationBuilder.DropTable(
                name: "traits");

            migrationBuilder.DropTable(
                name: "cats");

            migrationBuilder.DropTable(
                name: "CatBookUser");
        }
    }
}
