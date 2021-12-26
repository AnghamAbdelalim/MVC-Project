namespace Data_access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartDetails",
                c => new
                    {
                        CartDetailId = c.Int(nullable: false, identity: true),
                        ProductQuantity = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, storeType: "date"),
                        ProductId = c.Int(nullable: false),
                        ShoppingCartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartDetailId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCartId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ShoppingCartId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        ProductImage = c.String(),
                        ProductPrice = c.Int(nullable: false),
                        ProducteDiscount = c.Single(nullable: false),
                        AutherName = c.String(),
                        NumberOfPage = c.Int(nullable: false),
                        ProductQuantity = c.Int(nullable: false),
                        CategorysID = c.Int(nullable: false),
                        SuppliersID = c.Int(nullable: false),
                        OrderDetailsID = c.Int(nullable: false),
                        OrderDetails_OrderDetailId = c.Int(),
                        Category_CategoryId = c.Int(),
                        Supplier_SupplierId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetails_OrderDetailId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId)
                .Index(t => t.OrderDetails_OrderDetailId)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.Supplier_SupplierId);
            
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.String(maxLength: 128),
                        ApplicationUserIdentity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        City = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        PaymentId = c.Int(nullable: false),
                        Orderdate = c.String(),
                        Description = c.String(),
                        totalPrice = c.Int(nullable: false),
                        discount = c.Int(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        UserID = c.String(),
                        ShipoperID = c.Int(nullable: false),
                        appUserID_Id = c.String(maxLength: 128),
                        Shipper_ShipperID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.appUserID_Id)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: true)
                .ForeignKey("dbo.Shippers", t => t.Shipper_ShipperID)
                .Index(t => t.PaymentId)
                .Index(t => t.appUserID_Id)
                .Index(t => t.Shipper_ShipperID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        BillDate = c.String(),
                        ShipperDate = c.String(),
                        Discount = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        OrderID_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderID_OrderId)
                .Index(t => t.OrderID_OrderId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartId = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false, storeType: "date"),
                        TotalPrice = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        appUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ShoppingCartId)
                .ForeignKey("dbo.AspNetUsers", t => t.appUser_Id)
                .Index(t => t.appUser_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                        CategoryImage = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        CreditCadrdNumber = c.Int(nullable: false),
                        HolderName = c.String(),
                        Expire_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCardID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        CreditCadrdNumber = c.Int(nullable: false),
                        Bank = c.String(),
                        Branch = c.String(),
                        Expire_Date = c.DateTime(nullable: false),
                        CCV = c.Int(nullable: false),
                        CreditCardID_CreditCardID = c.Int(),
                        UserName_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.CreditCards", t => t.CreditCardID_CreditCardID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserName_Id)
                .Index(t => t.CreditCardID_CreditCardID)
                .Index(t => t.UserName_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperID = c.Int(nullable: false, identity: true),
                        ShipperMethod = c.String(),
                        CompanyName = c.String(),
                        PhoneNumber = c.String(),
                        shipper_date = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ShipperID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyEmail = c.String(),
                        Logo = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.WishlistProducts",
                c => new
                    {
                        Wishlist_ID = c.Int(nullable: false),
                        Product_ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Wishlist_ID, t.Product_ProductID })
                .ForeignKey("dbo.Wishlists", t => t.Wishlist_ID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductID, cascadeDelete: true)
                .Index(t => t.Wishlist_ID)
                .Index(t => t.Product_ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Orders", "Shipper_ShipperID", "dbo.Shippers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Payments", "UserName_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Payments", "CreditCardID_CreditCardID", "dbo.CreditCards");
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CartDetails", "ShoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.CartDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Wishlists", "ProductID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShoppingCarts", "appUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "OrderDetails_OrderDetailId", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetails", "OrderID_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "appUserID_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.WishlistProducts", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.WishlistProducts", "Wishlist_ID", "dbo.Wishlists");
            DropIndex("dbo.WishlistProducts", new[] { "Product_ProductID" });
            DropIndex("dbo.WishlistProducts", new[] { "Wishlist_ID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Payments", new[] { "UserName_Id" });
            DropIndex("dbo.Payments", new[] { "CreditCardID_CreditCardID" });
            DropIndex("dbo.ShoppingCarts", new[] { "appUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID_OrderId" });
            DropIndex("dbo.Orders", new[] { "Shipper_ShipperID" });
            DropIndex("dbo.Orders", new[] { "appUserID_Id" });
            DropIndex("dbo.Orders", new[] { "PaymentId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Wishlists", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropIndex("dbo.Products", new[] { "OrderDetails_OrderDetailId" });
            DropIndex("dbo.CartDetails", new[] { "ShoppingCartId" });
            DropIndex("dbo.CartDetails", new[] { "ProductId" });
            DropTable("dbo.WishlistProducts");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Shippers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Payments");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Categories");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Wishlists");
            DropTable("dbo.Products");
            DropTable("dbo.CartDetails");
        }
    }
}
