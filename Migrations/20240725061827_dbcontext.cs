using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Group41_Wired_Martians.Migrations
{
    /// <inheritdoc />
    public partial class dbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDetails",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surburb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetails", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surburb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuplierContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FridgeAllocations",
                columns: table => new
                {
                    AllocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    AllocationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllocationDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeAllocations", x => x.AllocationID);
                    table.ForeignKey(
                        name: "FK_FridgeAllocations_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnergyRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warranty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgThumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: true),
                    Availability = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Damaged = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventories_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    ColorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryID = table.Column<int>(type: "int", nullable: false),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.ColorID);
                    table.ForeignKey(
                        name: "FK_ProductColors_Inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventories",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItems",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllocationID = table.Column<int>(type: "int", nullable: false),
                    InventoryID = table.Column<int>(type: "int", nullable: false),
                    ColorID = table.Column<int>(type: "int", nullable: false),
                    ProductColorsColorID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItems", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_FridgeAllocations_AllocationID",
                        column: x => x.AllocationID,
                        principalTable: "FridgeAllocations",
                        principalColumn: "AllocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventories",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_ProductColors_ProductColorsColorID",
                        column: x => x.ProductColorsColorID,
                        principalTable: "ProductColors",
                        principalColumn: "ColorID");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "CreatedDate", "Description", "ImageURL", "Status" },
                values: new object[,]
                {
                    { 1, "Single Door Fridges", new DateOnly(2024, 7, 4), "Compact single door fridges suitable for small Drinks.", "https://bosscateringequipment.co.za/wp-content/uploads/2021/09/upright-single-300x360.jpg", "Active" },
                    { 2, "Double Door Fridges", new DateOnly(2024, 1, 8), "Spacious double door fridges with separate freezer compartments.", "https://bosscateringequipment.co.za/wp-content/uploads/2021/09/DOUBLE-DOOR-FRIDGE-300x275.jpg", "Active" },
                    { 3, "Chest Freezer", new DateOnly(2024, 6, 9), "a large container operated by electricity, with a lid that opens at the top, that stores food at a very cold temperature so that it freezes and can be kept safely for a long time", "https://www.mhcworld.co.za/cdn/shop/products/kic-kic-300l-white-chest-freezer-kcg300-6847168053337.jpg?v=1665110360", "Active" },
                    { 4, "Freezer Explosion-Proof", new DateOnly(2024, 9, 14), "Fast freezing Explosion-proof performance: Explosion Grade 2, ignition level G4.", "https://qtetech.com/uploads/products/Nihon%20Freezer/Nihon_Freezer_EP-400.jpg", "Active" },
                    { 5, "Under Bar", new DateOnly(2024, 7, 4), "Portable mini fridges ideal for Bars To keep Small Products.", "https://media.takealot.com/covers_images/9eda8640894e44e4bfd5c634ef80e4bb/s-pdpxl.file", "Active" }
                });

            migrationBuilder.InsertData(
                table: "CompanyDetails",
                columns: new[] { "CompanyID", "AddressLine1", "AddressLine2", "City", "CompanyName", "Email", "Fax", "Logo", "Phone", "Surburb", "code" },
                values: new object[] { 1, "444 Govan Mbeki St", null, "Gqeberha", "Wired Martians", "WWW.martiansinfo@wiredmartians.ac.za", " (678) 887-6079", "https://imgur.com/mBajPzE", " (678) 456-6699", "North End", 6001 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "AddressLine1", "Avatar", "City", "CustomerEmail", "CustomerNumber", "FirstName", "LastName", "Status", "Surburb", "code" },
                values: new object[,]
                {
                    { 1, "56 Main Street", "/Images/Profile-Avatars/Customer5.jpg", "Port Elizabeth", "Lathitaa.doe@gmail.com", "+27 -5684- 467", "Lathitaa", "Mjungula", "Active", "Nort End", 6001 },
                    { 2, "456 High Road", "/Images/Profile-Avatars/profile2.jpg", "Durban", "jane.smith@gmail.com", "+27 -9348 -234", "Jane", "Smith", "Active", "Morningside", 4001 },
                    { 3, "789 King Street", "/Images/Profile-Avatars/Customer4.jpg", "Johannesburg", "michael.brown@gmail.com", "+27 -5364 -645", "Michael", "Brown", "Active", "Sandton", 2196 },
                    { 4, "324 govan mbeki", "/Images/Profile-Avatars/Customer6.jpg", "Port Elizabeth", "Mila.Ngewu@gmail.com", "+27 -3255- 452", "Mila", "Ngewu", "Active", "North End", 6001 },
                    { 5, "34 Ivana Drive", "/Images/Profile-Avatars/Customer3.jpg", "Port Elizabeth", "Asive.Petu@gmail.com", "+27 -8332- 8877", "Asive", "Petu", "Active", "Summerstrand", 6001 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "Status", "SuplierContact", "SuplierEmail", "SupplierName" },
                values: new object[,]
                {
                    { 1, "Active", "+27-4556-890", "sales@cooltech.com", "CoolTech Refrigeration" },
                    { 2, "Active", "987-654-3210", "contact@kikappliances.com", "Kik Appliances" },
                    { 3, "Active", "+27-1273-567", "info@freshchill.com", "Fresh Chill Solutions" },
                    { 4, "Active", "444-555-6666", "support@frostyfreezers.com", "Frosty Freezers Inc." },
                    { 5, "Active", "+27-3343-444", "service@polarrefrigeration.com", "Polar Refrigeration" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Brand", "Capacity", "CategoryID", "Dimensions", "EnergyRating", "ImageFile", "ImgThumbnail", "ImgUrl", "ModelNumber", "ProductName", "Status", "SupplierID", "Warranty" },
                values: new object[,]
                {
                    { 1, "Fridgestar", "6000 Liters", 2, "420cm x 90cm x 115cm", "A", null, "https://example.com/thumb1.jpg", "https://bosscateringequipment.co.za/wp-content/uploads/2021/09/DOUBLE-DOOR-FRIDGE-300x275.jpg", "CSDF-100", "Display Fridge (Fridgestar) – Sliding Doors(Es1140)", "Active", 1, "12 Months" },
                    { 2, "Defy", "481 Liters", 3, "150cm x 60cm x 70cm", "A+", null, "https://example.com/thumb2.jpg", "https://www.rochester.co.za/media/catalog/product/cache/2bc2f148dc23cafaa22d929dc6e18cfe/1/0/10016037_ecommerce_98ae.png", "DDF-200", "Defy Chest Freezer ECO DMF456", "Active", 2, "24 Months" },
                    { 3, "LG", "420 Liters", 1, "180cm x 70cm x 80cm", "A++", null, "https://example.com/thumb3.jpg", "https://static.caterweb.co.za/5911-large_default/upright-freezer-420l-single-glass-door-.jpg", "SSSF-300", "LG FREEZER  - SINGLE GLASS DOOR", "Active", 3, "24 Months" },
                    { 4, "Crioni", "400 Liters", 5, "1800 x 750 x 900mm", "A+++", null, "https://example.com/thumb4.jpg", "https://static.caterweb.co.za/5904-large_default/25-glass-door-underbar-fridge.jpg", "FDF-400", "2.5 GLASS DOOR UNDERBAR FRIDGE", "Active", 4, "36 Months" },
                    { 5, "Nihon", "403 Liters", 4, "80cm x 40cm x 45cm", "A++", null, "https://example.com/thumb5.jpg", "https://qtetech.com/uploads/products/Nihon%20Freezer/Nihon_Freezer_EP-400.jpg", "PMF-50", "Nihon EP-400 Explosion-Proof Refrigerator 0-10oC", "Active", 5, "12 Months" }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryID", "Availability", "Brand", "Damaged", "IsDeleted", "Location", "ProductID", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 10, "Fridgestar", 0, false, "Warehouse A", 1, 10 },
                    { 2, 14, "Defy", 1, false, "Warehouse B", 2, 15 },
                    { 3, 6, "LG", 2, false, "Warehouse B", 3, 8 },
                    { 4, 20, "Crioni", 0, false, "Warehouse A", 4, 20 }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "ColorID", "ColorName", "Img", "InventoryID", "Qty" },
                values: new object[,]
                {
                    { 1, "Red", "https://example.com/red.jpg", 1, "5" },
                    { 2, "blue", "https://example.com/blue.jpg", 1, "5" },
                    { 3, "White", "https://example.com/white.jpg", 2, "7" },
                    { 4, "Black", "https://example.com/black.jpg", 2, "3" },
                    { 5, "Peach", "https://example.com/Peach.jpg", 2, "8" },
                    { 6, "White", "https://example.com/blue.jpg", 4, "20" },
                    { 7, "White", "https://example.com/blue.jpg", 3, "8" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeAllocations_CustomerID",
                table: "FridgeAllocations",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductID",
                table: "Inventories",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_InventoryID",
                table: "ProductColors",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierID",
                table: "Products",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_AllocationID",
                table: "PurchaseItems",
                column: "AllocationID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_InventoryID",
                table: "PurchaseItems",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_ProductColorsColorID",
                table: "PurchaseItems",
                column: "ProductColorsColorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CompanyDetails");

            migrationBuilder.DropTable(
                name: "PurchaseItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FridgeAllocations");

            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
