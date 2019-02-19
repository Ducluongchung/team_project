using EcommerceCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCore.Domain.Entities
{
   public class Customers : BaseEntity
    {
        public string FullName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Address1 { set; get; }
        public string Address2 { set; get; }
        public string City { set; get; }
        public string Country { set; get; }
        public string Phone { set; get; }
        public string Pass { set; get; }
        public string Note { set; get; }
        public DateTime LastVisit { set; get; }
        #region
        public virtual ShoppingCarts ShoppingCart { set; get; }
        public ICollection<OrderItems> OrderItem { set; get; }
        #endregion
    }
}
