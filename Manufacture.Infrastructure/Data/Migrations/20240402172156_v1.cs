using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manufacture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductToOrderRawMaterial_ProductToOrder_MaterialIdId",
                table: "ProductToOrderRawMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductToOrderRawMaterial_RawMaterials_ProductIdId",
                table: "ProductToOrderRawMaterial");

            migrationBuilder.RenameColumn(
                name: "ProductIdId",
                table: "ProductToOrderRawMaterial",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "MaterialIdId",
                table: "ProductToOrderRawMaterial",
                newName: "MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductToOrderRawMaterial_ProductIdId",
                table: "ProductToOrderRawMaterial",
                newName: "IX_ProductToOrderRawMaterial_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductToOrderRawMaterial_ProductToOrder_ProductId",
                table: "ProductToOrderRawMaterial",
                column: "ProductId",
                principalTable: "ProductToOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductToOrderRawMaterial_RawMaterials_MaterialId",
                table: "ProductToOrderRawMaterial",
                column: "MaterialId",
                principalTable: "RawMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductToOrderRawMaterial_ProductToOrder_ProductId",
                table: "ProductToOrderRawMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductToOrderRawMaterial_RawMaterials_MaterialId",
                table: "ProductToOrderRawMaterial");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductToOrderRawMaterial",
                newName: "ProductIdId");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "ProductToOrderRawMaterial",
                newName: "MaterialIdId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductToOrderRawMaterial_ProductId",
                table: "ProductToOrderRawMaterial",
                newName: "IX_ProductToOrderRawMaterial_ProductIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductToOrderRawMaterial_ProductToOrder_MaterialIdId",
                table: "ProductToOrderRawMaterial",
                column: "MaterialIdId",
                principalTable: "ProductToOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductToOrderRawMaterial_RawMaterials_ProductIdId",
                table: "ProductToOrderRawMaterial",
                column: "ProductIdId",
                principalTable: "RawMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
