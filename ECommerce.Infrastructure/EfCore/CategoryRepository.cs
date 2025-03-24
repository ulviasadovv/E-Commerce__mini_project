using ECommerce.Domain.Entities.Models;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore.Context;
using ECommerce.Infrastructure.EfCore.Core;

namespace ECommerce.Infrastructure.EfCore;

public class CategoryRepository : EfCoreRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}