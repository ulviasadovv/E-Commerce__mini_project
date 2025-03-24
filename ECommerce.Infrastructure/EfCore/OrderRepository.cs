using ECommerce.Domain.Entities.Models;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore.Context;
using ECommerce.Infrastructure.EfCore.Core;

namespace ECommerce.Infrastructure.EfCore
{
    internal class OrderRepository : EfCoreRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
