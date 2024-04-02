using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Manufacture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ProductionToOrder_ProductionToOrderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_ProductionToOrder_ProductionToOrderId",
                table: "RawMaterials");

            migrationBuilder.DropTable(
                name: "ProductionToOrder");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductionToOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductionToOrderId",
                table: "RawMaterials",
                newName: "ProductToOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_RawMaterials_ProductionToOrderId",
                table: "RawMaterials",
                newName: "IX_RawMaterials_ProductToOrderId");

            migrationBuilder.RenameColumn(
                name: "ProductionToOrderId",
                table: "Orders",
                newName: "ProductToOrderId");

            migrationBuilder.AddColumn<int>(
                name: "ProductToOrderId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductToOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToOrder", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductToOrderId",
                table: "Orders",
                column: "ProductToOrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ProductToOrder_ProductToOrderId",
                table: "Orders",
                column: "ProductToOrderId",
                principalTable: "ProductToOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_ProductToOrder_ProductToOrderId",
                table: "RawMaterials",
                column: "ProductToOrderId",
                principalTable: "ProductToOrder",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ProductToOrder_ProductToOrderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_ProductToOrder_ProductToOrderId",
                table: "RawMaterials");

            migrationBuilder.DropTable(
                name: "ProductToOrder");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductToOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductToOrderId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductToOrderId",
                table: "RawMaterials",
                newName: "ProductionToOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_RawMaterials_ProductToOrderId",
                table: "RawMaterials",
                newName: "IX_RawMaterials_ProductionToOrderId");

            migrationBuilder.RenameColumn(
                name: "ProductToOrderId",
                table: "Orders",
                newName: "ProductionToOrderId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductionToOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<int>(type: "integer", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionToOrder", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductionToOrderId",
                table: "Orders",
                column: "ProductionToOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ProductionToOrder_ProductionToOrderId",
                table: "Orders",
                column: "ProductionToOrderId",
                principalTable: "ProductionToOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_ProductionToOrder_ProductionToOrderId",
                table: "RawMaterials",
                column: "ProductionToOrderId",
                principalTable: "ProductionToOrder",
                principalColumn: "Id");
        }
    }
}
