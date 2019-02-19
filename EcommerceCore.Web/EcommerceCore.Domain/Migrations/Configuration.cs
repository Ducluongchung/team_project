﻿using System;
using System.Data.Entity;
using EcommerceCore.Domain.Entities;
using EcommerceCore.Domain.Enums;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EcommerceCore.Domain.Migrations
{
  
    public sealed class Configuration : DbMigrationsConfiguration<EcommerceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EcommerceDbContext context)
        {            
             DbContextSeed(context);
        }

        private  void DbContextSeed(EcommerceDbContext context, int retry = 0)
        {
            int retryForAvaiability = retry;
            try
            {
                SeedCategory(context);
                SeedSupplier(context);
                SeedManufacture(context);
                SeedProduct(context);
                SeedAuthencation(context);
            }
            catch (Exception ex)
            {
                if (retryForAvaiability < 10)
                {
                    retryForAvaiability++;

                    DbContextSeed(context, retryForAvaiability);
                }
            }
        }
        public void SeedAuthencation(EcommerceDbContext context)
        {
            var um = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            var user = new IdentityUser()
            {
                UserName = "admin",
                Email = "vansy9x@gmail.com"
            };
            IdentityResult ir = um.Create(user, "123456a@A");
        }
        public void SeedProduct(EcommerceDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.Add(new Product()
                {
                    UrlName = "Quần bò ngố",
                    CategoryId = context.Categories.FirstOrDefault(s => s.Name.Contains("Quần thời trang"))
                        .Id,
                    Depth = 10,
                    Description = "Iphone X sản xuất năm 2017",
                    ExpirationDate = DateTime.Now.Date,
                    Height = 10,
                    Keyword = "Iphone X",
                    ManufacturerId = context.Manufacturers.FirstOrDefault(s => s.CodeName.Contains("Sony")).Id,
                    Price = 20.54M,
                    Sku = "2423da13",
                    SupplierId = context.Suppliers.FirstOrDefault(s => s.CodeName.Contains("SSVN")).Id,
                    Title = "Iphone X - 2017",
                    Weight = 34.2
                });
                context.SaveChanges();
            }
        }

        public void SeedSupplier(EcommerceDbContext context)
        {
            if (!context.Suppliers.Any())
            {
                context.Suppliers.Add(new Supplier()
                {
                    Name = "FSI SHOP",
                    CodeName = "FSIS",
                    Email = "quangchau.vietnam@gmail.com",
                    Phone = "0971489926"
                });
                context.SaveChanges();

                context.Suppliers.Add(new Supplier()
                {
                    Name = "CMC Global",
                    CodeName = "CMCG",
                    Email = "quangchau@gmail.com",
                    Phone = "0971489926"
                });
                context.SaveChanges();
            }
        }

        public void SeedCategory(EcommerceDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category()
                {
                    Name = "Áo mùa hè",
                    Description = "Hàng quảng châu",
                    ParentId = null,
                    Status = CommonStatus.Active
                });

                context.Categories.Add(new Category()
                {
                    Name = "Áo mùa đông",
                    Description = "Hàng quảng châu",
                    ParentId = null,
                    Status = CommonStatus.Active
                });

                context.Categories.Add(new Category()
                {
                    Name = "Quần thời trang",
                    Description = "Hàng quảng châu",
                    ParentId = null,
                    Status = CommonStatus.Active
                });
                context.SaveChanges();
            }
        }

        public void SeedManufacture(EcommerceDbContext context)
        {
            if (!context.Manufacturers.Any())
            {
                context.Manufacturers.Add(new Manufacturer
                {
                    Name = "Louis Vuitton",
                    CodeName = "Louis Vuitton",
                    Website = "Louis.com.vn",
                    Status = CommonStatus.Active,
                    Logo = "",
                    Description = "Louis Manufacturer"
                });

                context.Manufacturers.Add(new Manufacturer
                {
                    Name = "CHANEL",
                    CodeName = "CHANEL",
                    Website = "CHANEL.com.vn",
                    Status = CommonStatus.Active,
                    Logo = "",
                    Description = "CHANEL Manufacturer"
                });

                context.Manufacturers.Add(new Manufacturer
                {
                    Name = "PRADA",
                    CodeName = "PRADA",
                    Website = "PRADA.com",
                    Status = CommonStatus.Active,
                    Logo = "",
                    Description = "PRADA Manufacturer"
                });
                context.SaveChanges();
            }
        }
    }
}
