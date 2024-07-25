using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group41_Wired_Martians.Migrations
{
    /// <inheritdoc />
    public partial class nulls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FridgeAllocations_Customers_CustomerID",
                table: "FridgeAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_ProductID",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_FridgeAllocations_AllocationID",
                table: "PurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Inventories_InventoryID",
                table: "PurchaseItems");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryID",
                table: "PurchaseItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ColorID",
                table: "PurchaseItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AllocationID",
                table: "PurchaseItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryID",
                table: "ProductColors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Inventories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "FridgeAllocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeAllocations_Customers_CustomerID",
                table: "FridgeAllocations",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_ProductID",
                table: "Inventories",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_FridgeAllocations_AllocationID",
                table: "PurchaseItems",
                column: "AllocationID",
                principalTable: "FridgeAllocations",
                principalColumn: "AllocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Inventories_InventoryID",
                table: "PurchaseItems",
                column: "InventoryID",
                principalTable: "Inventories",
                principalColumn: "InventoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FridgeAllocations_Customers_CustomerID",
                table: "FridgeAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_ProductID",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_FridgeAllocations_AllocationID",
                table: "PurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Inventories_InventoryID",
                table: "PurchaseItems");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryID",
                table: "PurchaseItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColorID",
                table: "PurchaseItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AllocationID",
                table: "PurchaseItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryID",
                table: "ProductColors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "FridgeAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeAllocations_Customers_CustomerID",
                table: "FridgeAllocations",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_ProductID",
                table: "Inventories",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_FridgeAllocations_AllocationID",
                table: "PurchaseItems",
                column: "AllocationID",
                principalTable: "FridgeAllocations",
                principalColumn: "AllocationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Inventories_InventoryID",
                table: "PurchaseItems",
                column: "InventoryID",
                principalTable: "Inventories",
                principalColumn: "InventoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
