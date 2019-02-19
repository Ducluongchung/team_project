using System.Data.Entity;
using System.Linq;
using EcommerceCore.Domain.Entities;
using EcommerceCore.Domain.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EcommerceCore.Domain
{
    public class EcommerceDbContextSeed : DropCreateDatabaseAlways<EcommerceDbContext>
    {
        protected override void Seed(EcommerceDbContext context)
        {

            SeedCategory(context);
            SeedSupplier(context);
            SeedAuthencation(context);
            base.Seed(context);
        }

        public void SeedAuthencation(EcommerceDbContext context)
        {
            var um = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            var user = new IdentityUser()
            {
                UserName = "Admin",
                Email = "vansy9x@gmail.com",
                EmailConfirmed = true,
            };
            IdentityResult ir = um.Create(user, "123");
        }
        public void SeedSupplier(EcommerceDbContext context)
        {
            if (!context.Suppliers.Any())
            {
                context.Suppliers.Add(new Supplier()
                {
                    Name = "Louis Vuitton",
                    CodeName = "SSVN",
                    Email = "Louis Vuitton.vietnam@gmail.com",
                    Phone = "0971489926"
                });
                context.SaveChanges();
            }
        }

        public void SeedCategory(EcommerceDbContext context)
        {

            context.Categories.Add(new Category()
            {
                Name = "Áo Khoác",
                Description = "Hàng quảng châu",
                ParentId = null,
                Status = CommonStatus.Active
            });

            context.Categories.Add(new Category()
            {
                Name = "Áo dạ",
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
}
