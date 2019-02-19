using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCore.Domain.Entities
{
   public class ShoppingCarts : BaseEntity
    {
        [Required]
        public virtual Customers Customer { set; get; }
        public int Quantity { set; get; }
        public decimal TotalPrice { set; get; }
        public Guid? ProductId { set; get; }
        public ICollection<Product> Products { set; get; }
    }
}
