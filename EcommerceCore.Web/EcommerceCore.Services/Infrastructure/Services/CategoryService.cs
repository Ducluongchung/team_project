using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceCore.Common.Service;
using EcommerceCore.Domain.Entities;
using EcommerceCore.Services.Infrastructure.Repositories;

namespace EcommerceCore.Services.Infrastructure.Services
{
    public class CategoryService: EntityService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category GetByProduct(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
