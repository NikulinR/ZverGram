using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZverGram.Db.Context.Migrations
{
    public partial class simplify_cat_ex_link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exhibitions_categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "exhibitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_exhibitions_CategoryId",
                table: "exhibitions",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_exhibitions_categories_CategoryId",
                table: "exhibitions",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exhibitions_categories_CategoryId",
                table: "exhibitions");

            migrationBuilder.DropIndex(
                name: "IX_exhibitions_CategoryId",
                table: "exhibitions");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "exhibitions");

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
                name: "IX_exhibitions_categories_ExhibitionsId",
                table: "exhibitions_categories",
                column: "ExhibitionsId");
        }
    }
}
