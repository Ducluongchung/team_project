using System;
using EcommerceCore.Common.Service;
using EcommerceCore.Domain.Entities;

namespace EcommerceCore.Services.Infrastructure.Services
{
    public interface ICategoryService : IEntityService<Category>
    {
        Category GetByProduct(Guid productId);
    }
}
