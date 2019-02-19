using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcommerceCore.Services.Infrastructure.ViewModels
{
    public class CategoryViewModel : BaseEntityViewModel
    {
        [Required]
        [MaxLength(250)]
        [DisplayName("Tên danh mục")]
        public string Name { get; set; }
        [StringLength(2048)]
        [DisplayName("Mô tả")]
        public string Description { get; set; }
        [DisplayName("Danh mục cha")]
        public Guid? ParentId { get; set; }
        [DisplayName("Id trang")]
        public Guid? SiteId { get; set; }
    }
}
