using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class product_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_GenreCategories_GenreCategoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCategoryID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubCategoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubCategoryID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "GenreCategoryID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GenreCategories_GenreCategoryID",
                table: "Products",
                column: "GenreCategoryID",
                principalTable: "GenreCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_GenreCategories_GenreCategoryID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "GenreCategoryID",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Bottom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dupatta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Models = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Top = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryID",
                table: "Products",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductID",
                table: "ProductDetail",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GenreCategories_GenreCategoryID",
                table: "Products",
                column: "GenreCategoryID",
                principalTable: "GenreCategories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCategoryID",
                table: "Products",
                column: "SubCategoryID",
                principalTable: "SubCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
