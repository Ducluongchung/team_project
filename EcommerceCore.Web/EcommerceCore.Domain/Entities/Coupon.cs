using System;
using System.Collections;
using System.Collections.Generic;

namespace EcommerceCore.Domain.Entities
{
    public class Coupon : BaseEntity
    {
        public string CouponCode { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid? SiteId { get; set; }
         public virtual ICollection<CatalogCoupon> CatalogCoupon { set; get; }
    }
}
