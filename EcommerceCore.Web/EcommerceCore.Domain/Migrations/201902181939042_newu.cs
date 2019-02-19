namespace EcommerceCore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CatalogCoupons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CodeName = c.String(),
                        Description = c.String(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        SiteId = c.Guid(),
                        ApplyForCategory = c.Guid(),
                        ApplyForProduct = c.Guid(),
                        CouponId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ApplyForCategory)
                .ForeignKey("dbo.Coupons", t => t.CouponId)
                .ForeignKey("dbo.Products", t => t.ApplyForProduct)
                .Index(t => t.ApplyForCategory)
                .Index(t => t.ApplyForProduct)
                .Index(t => t.CouponId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ParentId = c.Guid(),
                        SiteId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UrlName = c.String(),
                        Title = c.String(),
                        Sku = c.String(),
                        PublicationDate = c.DateTime(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        View = c.Int(nullable: false),
                        Keyword = c.String(),
                        ExpirationDate = c.DateTime(),
                        Description = c.String(),
                        ShortDescription = c.String(),
                        Weight = c.Double(),
                        Height = c.Double(),
                        Width = c.Double(),
                        Depth = c.Double(),
                        SiteId = c.Guid(),
                        CategoryId = c.Guid(),
                        SupplierId = c.Guid(),
                        ManufacturerId = c.Guid(),
                        ProductStatusId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ShoppingCart_Id = c.Guid(),
                        OrderItem_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCart_Id)
                .ForeignKey("dbo.OrderItems", t => t.OrderItem_Id)
                .ForeignKey("dbo.ProductStatus", t => t.ProductStatusId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.CategoryId)
                .Index(t => t.SupplierId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.ProductStatusId)
                .Index(t => t.ShoppingCart_Id)
                .Index(t => t.OrderItem_Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CodeName = c.String(),
                        Description = c.String(),
                        Website = c.String(),
                        Logo = c.String(),
                        SiteId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Customer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Pass = c.String(),
                        Note = c.String(),
                        LastVisit = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Pass = c.String(),
                        Note = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ImageLink = c.String(),
                        SequenceNo = c.Int(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductPrices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MinQuantity = c.Int(nullable: false),
                        MaxQuantity = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CodeName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        SiteId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CouponCode = c.String(),
                        Name = c.String(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        SiteId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CatalogCoupons", "ApplyForProduct", "dbo.Products");
            DropForeignKey("dbo.CatalogCoupons", "CouponId", "dbo.Coupons");
            DropForeignKey("dbo.CatalogCoupons", "ApplyForCategory", "dbo.Categories");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "ProductStatusId", "dbo.ProductStatus");
            DropForeignKey("dbo.ProductPrices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "OrderItem_Id", "dbo.OrderItems");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "ShoppingCart_Id", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ShoppingCarts", "Id", "dbo.Customers");
            DropForeignKey("dbo.OrderItems", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductPrices", new[] { "ProductId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.ShoppingCarts", new[] { "Id" });
            DropIndex("dbo.OrderItems", new[] { "Customer_Id" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Products", new[] { "OrderItem_Id" });
            DropIndex("dbo.Products", new[] { "ShoppingCart_Id" });
            DropIndex("dbo.Products", new[] { "ProductStatusId" });
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.CatalogCoupons", new[] { "CouponId" });
            DropIndex("dbo.CatalogCoupons", new[] { "ApplyForProduct" });
            DropIndex("dbo.CatalogCoupons", new[] { "ApplyForCategory" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Coupons");
            DropTable("dbo.Suppliers");
            DropTable("dbo.ProductStatus");
            DropTable("dbo.ProductPrices");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Orders");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.Customers");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.CatalogCoupons");
        }
    }
}
