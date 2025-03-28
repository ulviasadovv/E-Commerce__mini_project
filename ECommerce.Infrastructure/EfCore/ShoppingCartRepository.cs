using ECommerce.Domain.Entities.Models;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore.Context;
using ECommerce.Infrastructure.EfCore.Core;

namespace ECommerce.Infrastructure.EfCore;

public class ShoppingCartRepository : EfCoreRepository<ShoppingCart>, IShoppingCartRepository
{
    public ShoppingCartRepository(AppDbContext context) : base(context)
    {
    }
}