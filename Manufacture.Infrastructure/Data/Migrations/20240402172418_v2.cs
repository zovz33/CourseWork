using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manufacture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductToOrderId",
                table: "Products",
                column: "ProductToOrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductToOrder_ProductToOrderId",
                table: "Products",
                column: "ProductToOrderId",
                principalTable: "ProductToOrder",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductToOrder_ProductToOrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductToOrderId",
                table: "Products");
        }
    }
}
