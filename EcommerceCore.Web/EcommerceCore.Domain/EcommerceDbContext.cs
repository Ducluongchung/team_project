using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceCore.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EcommerceCore.Domain
{
    public class EcommerceDbContext :  IdentityDbContext<IdentityUser> //DbContext
    {
        public EcommerceDbContext() : base("EcommerceDbContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<EcommerceDbContext>());
           // Database.SetInitializer(new EcommerceDbContextSeed());            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CatalogCoupon> catalogCoupons { set; get; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<Orders> Order { set; get; }
        public DbSet<OrderItems> OrderItem { set; get; }
        public DbSet<Customers> Customer { set; get; }
        public DbSet<ShoppingCarts> ShoppingCart { set; get; }



    }
}
