using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class MainSubGenre_categoryies_fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreCategories_MainCategories_MainCategoryID",
                table: "GenreCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_GenreCategories_GenreCategoryID",
                table: "SubCategories");

            migrationBuilder.RenameColumn(
                name: "GenreCategoryID",
                table: "SubCategories",
                newName: "MainCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_GenreCategoryID",
                table: "SubCategories",
                newName: "IX_SubCategories_MainCategoryID");

            migrationBuilder.RenameColumn(
                name: "MainCategoryID",
                table: "GenreCategories",
                newName: "SubCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_GenreCategories_MainCategoryID",
                table: "GenreCategories",
                newName: "IX_GenreCategories_SubCategoryID");

            migrationBuilder.AddColumn<int>(
                name: "GenreCategoryID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_GenreCategoryID",
                table: "Products",
                column: "GenreCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreCategories_SubCategories_SubCategoryID",
                table: "GenreCategories",
                column: "SubCategoryID",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GenreCategories_GenreCategoryID",
                table: "Products",
                column: "GenreCategoryID",
                principalTable: "GenreCategories",
                principalColumn: "GenreCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_MainCategories_MainCategoryID",
                table: "SubCategories",
                column: "MainCategoryID",
                principalTable: "MainCategories",
                principalColumn: "MainCategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreCategories_SubCategories_SubCategoryID",
                table: "GenreCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_GenreCategories_GenreCategoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_MainCategories_MainCategoryID",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_GenreCategoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GenreCategoryID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "MainCategoryID",
                table: "SubCategories",
                newName: "GenreCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_MainCategoryID",
                table: "SubCategories",
                newName: "IX_SubCategories_GenreCategoryID");

            migrationBuilder.RenameColumn(
                name: "SubCategoryID",
                table: "GenreCategories",
                newName: "MainCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_GenreCategories_SubCategoryID",
                table: "GenreCategories",
                newName: "IX_GenreCategories_MainCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreCategories_MainCategories_MainCategoryID",
                table: "GenreCategories",
                column: "MainCategoryID",
                principalTable: "MainCategories",
                principalColumn: "MainCategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_GenreCategories_GenreCategoryID",
                table: "SubCategories",
                column: "GenreCategoryID",
                principalTable: "GenreCategories",
                principalColumn: "GenreCategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
