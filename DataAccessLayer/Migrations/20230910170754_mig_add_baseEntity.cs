using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_add_baseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodySizeProduct_BodySizes_BodySizesBodySizeID",
                table: "BodySizeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BodySizeProduct_Products_ProductsProductID",
                table: "BodySizeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ColorProduct_Colors_ColorsColorID",
                table: "ColorProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ColorProduct_Products_ProductsProductID",
                table: "ColorProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Products_ProductsProductID",
                table: "ProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Tags_TagsTagID",
                table: "ProductTag");

            migrationBuilder.RenameColumn(
                name: "WishListID",
                table: "WishLists",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "TagID",
                table: "Tags",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SubCategoryID",
                table: "SubCategories",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "StockID",
                table: "Stocks",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SponsorID",
                table: "Sponsors",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SocialMediaID",
                table: "SocialMedias",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ServiceID",
                table: "Services",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "TagsTagID",
                table: "ProductTag",
                newName: "TagsID");

            migrationBuilder.RenameColumn(
                name: "ProductsProductID",
                table: "ProductTag",
                newName: "ProductsID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTag_TagsTagID",
                table: "ProductTag",
                newName: "IX_ProductTag_TagsID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Products",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ProductDetailID",
                table: "ProductDetails",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "MainCategoryID",
                table: "MainCategories",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "GenreCategoryID",
                table: "GenreCategories",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "FeatureID",
                table: "Features",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ContactUsID",
                table: "ContactUss",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ContactID",
                table: "Contacts",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CommentID",
                table: "Comments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ColorID",
                table: "Colors",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ProductsProductID",
                table: "ColorProduct",
                newName: "ProductsID");

            migrationBuilder.RenameColumn(
                name: "ColorsColorID",
                table: "ColorProduct",
                newName: "ColorsID");

            migrationBuilder.RenameIndex(
                name: "IX_ColorProduct_ProductsProductID",
                table: "ColorProduct",
                newName: "IX_ColorProduct_ProductsID");

            migrationBuilder.RenameColumn(
                name: "BrandID",
                table: "Brands",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "BodySizeID",
                table: "BodySizes",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ProductsProductID",
                table: "BodySizeProduct",
                newName: "ProductsID");

            migrationBuilder.RenameColumn(
                name: "BodySizesBodySizeID",
                table: "BodySizeProduct",
                newName: "BodySizesID");

            migrationBuilder.RenameIndex(
                name: "IX_BodySizeProduct_ProductsProductID",
                table: "BodySizeProduct",
                newName: "IX_BodySizeProduct_ProductsID");

            migrationBuilder.RenameColumn(
                name: "AboutID",
                table: "Abouts",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BodySizeProduct_BodySizes_BodySizesID",
                table: "BodySizeProduct",
                column: "BodySizesID",
                principalTable: "BodySizes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BodySizeProduct_Products_ProductsID",
                table: "BodySizeProduct",
                column: "ProductsID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColorProduct_Colors_ColorsID",
                table: "ColorProduct",
                column: "ColorsID",
                principalTable: "Colors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColorProduct_Products_ProductsID",
                table: "ColorProduct",
                column: "ProductsID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Products_ProductsID",
                table: "ProductTag",
                column: "ProductsID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Tags_TagsID",
                table: "ProductTag",
                column: "TagsID",
                principalTable: "Tags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodySizeProduct_BodySizes_BodySizesID",
                table: "BodySizeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BodySizeProduct_Products_ProductsID",
                table: "BodySizeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ColorProduct_Colors_ColorsID",
                table: "ColorProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ColorProduct_Products_ProductsID",
                table: "ColorProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Products_ProductsID",
                table: "ProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Tags_TagsID",
                table: "ProductTag");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "WishLists",
                newName: "WishListID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Tags",
                newName: "TagID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SubCategories",
                newName: "SubCategoryID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Stocks",
                newName: "StockID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Sponsors",
                newName: "SponsorID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SocialMedias",
                newName: "SocialMediaID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Services",
                newName: "ServiceID");

            migrationBuilder.RenameColumn(
                name: "TagsID",
                table: "ProductTag",
                newName: "TagsTagID");

            migrationBuilder.RenameColumn(
                name: "ProductsID",
                table: "ProductTag",
                newName: "ProductsProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTag_TagsID",
                table: "ProductTag",
                newName: "IX_ProductTag_TagsTagID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Products",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ProductDetails",
                newName: "ProductDetailID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "MainCategories",
                newName: "MainCategoryID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "GenreCategories",
                newName: "GenreCategoryID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Features",
                newName: "FeatureID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ContactUss",
                newName: "ContactUsID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Contacts",
                newName: "ContactID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Comments",
                newName: "CommentID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Colors",
                newName: "ColorID");

            migrationBuilder.RenameColumn(
                name: "ProductsID",
                table: "ColorProduct",
                newName: "ProductsProductID");

            migrationBuilder.RenameColumn(
                name: "ColorsID",
                table: "ColorProduct",
                newName: "ColorsColorID");

            migrationBuilder.RenameIndex(
                name: "IX_ColorProduct_ProductsID",
                table: "ColorProduct",
                newName: "IX_ColorProduct_ProductsProductID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Brands",
                newName: "BrandID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "BodySizes",
                newName: "BodySizeID");

            migrationBuilder.RenameColumn(
                name: "ProductsID",
                table: "BodySizeProduct",
                newName: "ProductsProductID");

            migrationBuilder.RenameColumn(
                name: "BodySizesID",
                table: "BodySizeProduct",
                newName: "BodySizesBodySizeID");

            migrationBuilder.RenameIndex(
                name: "IX_BodySizeProduct_ProductsID",
                table: "BodySizeProduct",
                newName: "IX_BodySizeProduct_ProductsProductID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Abouts",
                newName: "AboutID");

            migrationBuilder.AddForeignKey(
                name: "FK_BodySizeProduct_BodySizes_BodySizesBodySizeID",
                table: "BodySizeProduct",
                column: "BodySizesBodySizeID",
                principalTable: "BodySizes",
                principalColumn: "BodySizeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BodySizeProduct_Products_ProductsProductID",
                table: "BodySizeProduct",
                column: "ProductsProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColorProduct_Colors_ColorsColorID",
                table: "ColorProduct",
                column: "ColorsColorID",
                principalTable: "Colors",
                principalColumn: "ColorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColorProduct_Products_ProductsProductID",
                table: "ColorProduct",
                column: "ProductsProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Products_ProductsProductID",
                table: "ProductTag",
                column: "ProductsProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Tags_TagsTagID",
                table: "ProductTag",
                column: "TagsTagID",
                principalTable: "Tags",
                principalColumn: "TagID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
