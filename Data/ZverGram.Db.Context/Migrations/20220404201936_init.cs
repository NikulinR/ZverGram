using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZverGram.Db.Context.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "exhibitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exhibitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExhibitionId = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Posted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "exhibitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exhibitions_categories",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ExhibitionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exhibitions_categories", x => new { x.CategoriesId, x.ExhibitionsId });
                    table.ForeignKey(
                        name: "FK_exhibitions_categories_categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_exhibitions_categories_exhibitions_ExhibitionsId",
                        column: x => x.ExhibitionsId,
                        principalTable: "exhibitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_Uid",
                table: "categories",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_ExhibitionId",
                table: "comments",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_Uid",
                table: "comments",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_exhibitions_Name",
                table: "exhibitions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_exhibitions_Uid",
                table: "exhibitions",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_exhibitions_categories_ExhibitionsId",
                table: "exhibitions_categories",
                column: "ExhibitionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "exhibitions_categories");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "exhibitions");
        }
    }
}
