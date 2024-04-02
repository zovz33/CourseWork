using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manufacture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_ProductToOrder_ProductToOrderId",
                table: "RawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_RawMaterials_ProductToOrderId",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "ProductToOrderId",
                table: "RawMaterials");

            migrationBuilder.CreateTable(
                name: "ProductToOrderRawMaterial",
                columns: table => new
                {
                    ProductMaterialId = table.Column<int>(type: "integer", nullable: false),
                    ProductMaterialId1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToOrderRawMaterial", x => new { x.ProductMaterialId, x.ProductMaterialId1 });
                    table.ForeignKey(
                        name: "FK_ProductToOrderRawMaterial_ProductToOrder_ProductMaterialId1",
                        column: x => x.ProductMaterialId1,
                        principalTable: "ProductToOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductToOrderRawMaterial_RawMaterials_ProductMaterialId",
                        column: x => x.ProductMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductToOrderRawMaterial_ProductMaterialId1",
                table: "ProductToOrderRawMaterial",
                column: "ProductMaterialId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductToOrderRawMaterial");

            migrationBuilder.AddColumn<int>(
                name: "ProductToOrderId",
                table: "RawMaterials",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_ProductToOrderId",
                table: "RawMaterials",
                column: "ProductToOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_ProductToOrder_ProductToOrderId",
                table: "RawMaterials",
                column: "ProductToOrderId",
                principalTable: "ProductToOrder",
                principalColumn: "Id");
        }
    }
}
