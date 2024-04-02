using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manufacture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductToOrderRawMaterial_ProductToOrder_ProductMaterialId1",
                table: "ProductToOrderRawMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductToOrderRawMaterial_RawMaterials_ProductMaterialId",
                table: "ProductToOrderRawMaterial");

            migrationBuilder.RenameColumn(
                name: "ProductMaterialId1",
                table: "ProductToOrderRawMaterial",
                newName: "ProductIdId");

            migrationBuilder.RenameColumn(
                name: "ProductMaterialId",
                table: "ProductToOrderRawMaterial",
                newName: "MaterialIdId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductToOrderRawMaterial_ProductMaterialId1",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "ProductMaterialId1");

            migrationBuilder.RenameColumn(
                name: "MaterialIdId",
                table: "ProductToOrderRawMaterial",
                newName: "ProductMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductToOrderRawMaterial_ProductIdId",
                table: "ProductToOrderRawMaterial",
                newName: "IX_ProductToOrderRawMaterial_ProductMaterialId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductToOrderRawMaterial_ProductToOrder_ProductMaterialId1",
                table: "ProductToOrderRawMaterial",
                column: "ProductMaterialId1",
                principalTable: "ProductToOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductToOrderRawMaterial_RawMaterials_ProductMaterialId",
                table: "ProductToOrderRawMaterial",
                column: "ProductMaterialId",
                principalTable: "RawMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
