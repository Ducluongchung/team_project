using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCore.Domain.Entities
{
   public class OrderItems : BaseEntity
    {
        public int Quantity { set; get; }
        public decimal TotalPrice { set; get; }

        public Guid? OrderId { set; get; }

        [ForeignKey("OrderId")]
        public virtual Orders Order { set; get; }
        public virtual Customers Customer { set; get; }

        public ICollection<Product> products { set; get; }
    }
}
