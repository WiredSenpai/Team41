using Group41_Wired_Martians.Areas.Identity.Data;
using Group41_Wired_Martians.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Group41_Wired_Martians.Areas.Identity.Data;

public class AppDbContext : IdentityDbContext<Users>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    /// <summary>
    /// ////////////////////////////////////////////////PRODUCT MANAGEMENT///////////////////////////////////////////////
    /// </summary>
    /// 
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<CompanyDetails> CompanyDetails { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<ProductColors> ProductColors { get; set; }
    public DbSet<FridgeAllocation> FridgeAllocations { get; set; }
    public DbSet<PurchaseItem> PurchaseItems { get; set; }


    /// <summary>
    /// ////////////////////////////////////////////////Customer Management///////////////////////////////////////////////
    /// </summary>
    /// 
    public DbSet<Customer> Customers { get; set; }

    /// <summary>
    /// ////////////////////////////////////////////////Customer Management///////////////////////////////////////////////
    /// </summary>
    /// 

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Inventory>()
        .HasMany(i => i.ProductColors)
        .WithOne(pc => pc.Inventory)
        .HasForeignKey(pc => pc.InventoryID)
        .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CompanyDetails>().HasData(
              new CompanyDetails
              {
                  CompanyID = 1,
                  CompanyName = "Wired Martians",
                  Logo = "https://imgur.com/mBajPzE",
                  AddressLine1 = "444 Govan Mbeki St",
                  AddressLine2 = null,
                  Surburb = "North End",
                  City = "Gqeberha",
                  code = 6001,
                  Phone = " (678) 456-6699",
                  Fax = " (678) 887-6079",
                  Email = "WWW.martiansinfo@wiredmartians.ac.za",
              }
          );

        builder.Entity<Supplier>().HasData(
             new Supplier
             {
                 SupplierID = 1,
                 SupplierName = "CoolTech Refrigeration",
                 SuplierEmail = "sales@cooltech.com",
                 SuplierContact = "+27-4556-890",
                 Status = "Active"
             },
             new Supplier
             {
                 SupplierID = 2,
                 SupplierName = "Kik Appliances",
                 SuplierEmail = "contact@kikappliances.com",
                 SuplierContact = "987-654-3210",
                 Status = "Active"
             },
             new Supplier
             {
                 SupplierID = 3,
                 SupplierName = "Fresh Chill Solutions",
                 SuplierEmail = "info@freshchill.com",
                 SuplierContact = "+27-1273-567",
                 Status = "Active"
             },
             new Supplier
             {
                 SupplierID = 4,
                 SupplierName = "Frosty Freezers Inc.",
                 SuplierEmail = "support@frostyfreezers.com",
                 SuplierContact = "444-555-6666",
                 Status = "Active"
             },
             new Supplier
             {
                 SupplierID = 5,
                 SupplierName = "Polar Refrigeration",
                 SuplierEmail = "service@polarrefrigeration.com",
                 SuplierContact = "+27-3343-444",
                 Status = "Active"
             }
         );
        builder.Entity<Customer>().HasData(
               new Customer
               {
                   CustomerID = 1,
                   Avatar = "/Images/Profile-Avatars/Customer5.jpg",
                   FirstName = "Lathitaa",
                   LastName = "Mjungula",
                   CustomerNumber = "+27 -5684- 467",
                   CustomerEmail = "Lathitaa.doe@gmail.com",
                   AddressLine1 = "56 Main Street",
                   Surburb = "Nort End",
                   City = "Port Elizabeth",
                   code = 6001,
                   Status = "Active"
               },
               new Customer
               {
                   CustomerID = 2,
                   Avatar="/Images/Profile-Avatars/profile2.jpg",
                   FirstName = "Jane",
                   LastName = "Smith",
                   CustomerNumber = "+27 -9348 -234",
                   CustomerEmail = "jane.smith@gmail.com",
                   AddressLine1 = "456 High Road",
                   Surburb = "Morningside",
                   City = "Durban",
                   code = 4001,
                   Status = "Active"
               },
               new Customer
               {
                   CustomerID = 3,
                   Avatar = "/Images/Profile-Avatars/Customer4.jpg",
                   FirstName = "Michael",
                   LastName = "Brown",
                   CustomerNumber = "+27 -5364 -645",
                   CustomerEmail = "michael.brown@gmail.com",
                   AddressLine1 = "789 King Street",
                   Surburb = "Sandton",
                   City = "Johannesburg",
                   code = 2196,
                   Status = "Active"
               },
               new Customer
               {
                   CustomerID = 4,
                   Avatar = "/Images/Profile-Avatars/Customer6.jpg",
                   FirstName = "Mila",
                   LastName = "Ngewu",
                   CustomerNumber = "+27 -3255- 452",
                   CustomerEmail = "Mila.Ngewu@gmail.com",
                   AddressLine1 = "324 govan mbeki",
                   Surburb = "North End",
                   City = "Port Elizabeth",
                   code = 6001,
                   Status = "Active"
               },
               new Customer
               {
                   CustomerID = 5,
                   Avatar = "/Images/Profile-Avatars/Customer3.jpg",
                   FirstName = "Asive",
                   LastName = "Petu",
                   CustomerNumber = "+27 -8332- 8877",
                   CustomerEmail = "Asive.Petu@gmail.com",
                   AddressLine1 = "34 Ivana Drive",
                   Surburb = "Summerstrand",
                   City = "Port Elizabeth",
                   code = 6001,
                   Status = "Active"
               }
           );

        builder.Entity<Category>().HasData(
           new Category
           {
               CategoryID = 1,
               CategoryName = "Single Door Fridges",
               Description = "Compact single door fridges suitable for small Drinks.",
               ImageURL = "https://bosscateringequipment.co.za/wp-content/uploads/2021/09/upright-single-300x360.jpg",
               CreatedDate = new DateOnly(2024 ,7 ,4),
               Status = "Active"
           },
           new Category
           {
               CategoryID = 2,
               CategoryName = "Double Door Fridges",
               Description = "Spacious double door fridges with separate freezer compartments.",
               ImageURL = "https://bosscateringequipment.co.za/wp-content/uploads/2021/09/DOUBLE-DOOR-FRIDGE-300x275.jpg",
               CreatedDate = new DateOnly(2024, 1, 8),
               Status = "Active"
           },
           new Category
           {
               CategoryID = 3,
               CategoryName = "Chest Freezer",
               Description = "a large container operated by electricity, with a lid that opens at the top, that stores food at a very cold temperature so that it freezes and can be kept safely for a long time",
               ImageURL = "https://www.mhcworld.co.za/cdn/shop/products/kic-kic-300l-white-chest-freezer-kcg300-6847168053337.jpg?v=1665110360",
               CreatedDate = new DateOnly(2024, 6, 9),
               Status = "Active"
           },
           new Category
           {
               CategoryID = 4,
               CategoryName = "Freezer Explosion-Proof",
               Description = "Fast freezing Explosion-proof performance: Explosion Grade 2, ignition level G4.",
               ImageURL = "https://qtetech.com/uploads/products/Nihon%20Freezer/Nihon_Freezer_EP-400.jpg",
               CreatedDate = new DateOnly(2024, 9,14),
               Status = "Active"
           },
           new Category
           {
               CategoryID = 5,
               CategoryName = "Under Bar",
               Description = "Portable mini fridges ideal for Bars To keep Small Products.",
               ImageURL = "https://media.takealot.com/covers_images/9eda8640894e44e4bfd5c634ef80e4bb/s-pdpxl.file",
               CreatedDate = new DateOnly(2024, 7, 4),
               Status = "Active"
           }
       );

        builder.Entity<Product>().HasData(
       new Product
       {
           ProductID = 1,
           ProductName = "Display Fridge (Fridgestar) – Sliding Doors(Es1140)",
           Brand = "Fridgestar",
           CategoryID = 2, // Single Door Fridges
           SupplierID = 1, // CoolTech Refrigeration
           ModelNumber = "CSDF-100",
           Capacity = "6000 Liters",
           EnergyRating = "A",
           Dimensions = "420cm x 90cm x 115cm",
           Warranty = "12 Months",
           Status = "Active",
           ImgUrl = "https://bosscateringequipment.co.za/wp-content/uploads/2021/09/DOUBLE-DOOR-FRIDGE-300x275.jpg",
           ImgThumbnail = "https://example.com/thumb1.jpg"
       },
       new Product
       {
           ProductID = 2,
           ProductName = "Defy Chest Freezer ECO DMF456",
           Brand = "Defy",
           CategoryID = 3, // Double Door Fridges
           SupplierID = 2, // Kik Appliances
           ModelNumber = "DDF-200",
           Capacity = "481 Liters",
           EnergyRating = "A+",
           Dimensions = "150cm x 60cm x 70cm",
           Warranty = "24 Months",
           Status = "Active",
           ImgUrl = "https://www.rochester.co.za/media/catalog/product/cache/2bc2f148dc23cafaa22d929dc6e18cfe/1/0/10016037_ecommerce_98ae.png",
           ImgThumbnail = "https://example.com/thumb2.jpg"
       },
       new Product
       {
           ProductID = 3,
           ProductName = "LG FREEZER  - SINGLE GLASS DOOR",
           Brand = "LG",
           CategoryID = 1, // Side-by-Side Fridges
           SupplierID = 3, // Fresh Chill Solutions
           ModelNumber = "SSSF-300",
           Capacity = "420 Liters",
           EnergyRating = "A++",
           Dimensions = "180cm x 70cm x 80cm",
           Warranty = "24 Months",
           Status = "Active",
           ImgUrl = "https://static.caterweb.co.za/5911-large_default/upright-freezer-420l-single-glass-door-.jpg",
           ImgThumbnail = "https://example.com/thumb3.jpg"
       },
       new Product
       {
           ProductID = 4,
           ProductName = "2.5 GLASS DOOR UNDERBAR FRIDGE",
           Brand = "Crioni",
           CategoryID = 5, // French Door Fridges
           SupplierID = 4, // Frosty Freezers Inc.
           ModelNumber = "FDF-400",
           Capacity = "400 Liters",
           EnergyRating = "A+++",
           Dimensions = "1800 x 750 x 900mm",
           Warranty = "36 Months",
           Status = "Active",
           ImgUrl = "https://static.caterweb.co.za/5904-large_default/25-glass-door-underbar-fridge.jpg",
           ImgThumbnail = "https://example.com/thumb4.jpg"
       },
       new Product
       {
           ProductID = 5,
           ProductName = "Nihon EP-400 Explosion-Proof Refrigerator 0-10oC",
           Brand = "Nihon",
           CategoryID = 4, // Mini Fridges
           SupplierID = 5, // Polar Refrigeration
           ModelNumber = "PMF-50",
           Capacity = "403 Liters",
           EnergyRating = "A++",
           Dimensions = "80cm x 40cm x 45cm",
           Warranty = "12 Months",
           Status = "Active",
           ImgUrl = "https://qtetech.com/uploads/products/Nihon%20Freezer/Nihon_Freezer_EP-400.jpg",
           ImgThumbnail = "https://example.com/thumb5.jpg"
       }
      );

        builder.Entity<Inventory>().HasData(
        new Inventory
        {
            InventoryID = 1,
            ProductID = 1,
            StockQuantity = 10,
            Availability = 10,
            Location = "Warehouse A",
            Brand = "Fridgestar",
            Damaged = 0,

        },
        new Inventory
        {
            InventoryID = 2,
            ProductID = 2,
            StockQuantity = 15,
            Availability = 14,
            Location = "Warehouse B",
            Brand = "Defy",
            Damaged = 1,

        },
        new Inventory
        {
            InventoryID = 3,
            ProductID = 3,
            StockQuantity = 8,
            Availability = 6,
            Location = "Warehouse B",
            Brand = "LG",
            Damaged = 2,

        },
        new Inventory
        {
            InventoryID = 4,
            ProductID = 4,
            StockQuantity = 20,
            Availability = 20,
            Location = "Warehouse A",
            Brand = "Crioni",
            Damaged = 0,

        }
        );

        builder.Entity<ProductColors>().HasData(
        new ProductColors
        {
            ColorID = 1,
            InventoryID = 1,
            ColorName = "Red",
            Img = "https://example.com/red.jpg",
            Qty = "5"
        },
         new ProductColors
         {
             ColorID = 2,
             InventoryID = 1,
             ColorName = "blue",
             Img = "https://example.com/blue.jpg",
             Qty = "5"
         },

        new ProductColors
        {
            ColorID = 3,
            InventoryID = 2,
            ColorName = "White",
            Img = "https://example.com/white.jpg",
            Qty ="7"
        },
        new ProductColors
        {
            ColorID = 4,
            InventoryID = 2,
            ColorName = "Black",
            Img = "https://example.com/black.jpg",
            Qty ="3"
        },

          new ProductColors
          {
              ColorID = 5,
              InventoryID = 2,
              ColorName = "Peach",
              Img = "https://example.com/Peach.jpg",
              Qty = "8"
          },

             new ProductColors
             {
                 ColorID = 6,
                 InventoryID = 4,
                 ColorName = "White",
                 Img = "https://example.com/blue.jpg",
                 Qty = "20"
             },
                  new ProductColors
                  {
                      ColorID = 7,
                      InventoryID = 3,
                      ColorName = "White",
                      Img = "https://example.com/blue.jpg",
                      Qty = "8"
                  }
    );
    }
}
