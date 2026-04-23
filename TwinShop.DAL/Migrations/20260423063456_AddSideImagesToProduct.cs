using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwinShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSideImagesToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSideImage_Products_ProductId",
                table: "ProductSideImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSideImage",
                table: "ProductSideImage");

            migrationBuilder.RenameTable(
                name: "ProductSideImage",
                newName: "productSideImages");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSideImage_ProductId",
                table: "productSideImages",
                newName: "IX_productSideImages_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_productSideImages",
                table: "productSideImages",
                column: "SideImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_productSideImages_Products_ProductId",
                table: "productSideImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productSideImages_Products_ProductId",
                table: "productSideImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productSideImages",
                table: "productSideImages");

            migrationBuilder.RenameTable(
                name: "productSideImages",
                newName: "ProductSideImage");

            migrationBuilder.RenameIndex(
                name: "IX_productSideImages_ProductId",
                table: "ProductSideImage",
                newName: "IX_ProductSideImage_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSideImage",
                table: "ProductSideImage",
                column: "SideImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSideImage_Products_ProductId",
                table: "ProductSideImage",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
