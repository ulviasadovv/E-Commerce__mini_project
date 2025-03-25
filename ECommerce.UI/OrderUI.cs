using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Domain.Entities.Models;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore;
using ECommerce.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.UI
{
    public class OrderUI
    {
        public static void PlaceOrder(User user)
        {
            var appDbContext = new AppDbContext();
            IOrderRepository orderRepository = new OrderRepository(appDbContext);
            IOrderService orderService = new OrderManager(orderRepository);

            var orders = appDbContext.Orders.Include(x => x.User).ToList();
            if (orders.Count == 0)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            Console.WriteLine("=== Orders ===");
            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {order.Id}, User: {order.User.FullName}, Status: {order.Status}");
            }
        }

    }
}
