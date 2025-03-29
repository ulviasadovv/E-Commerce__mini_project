using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore;
using ECommerce.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.UI
{
    public class OrderUI
    {
        public static void PlaceOrder()
        {

            Console.Clear();
            Console.WriteLine("Press \"0\" to exit: ");

            var appDbContext = new AppDbContext();
            IShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository(appDbContext);
            IShoppingCartService shoppingCartService = new ShoppingCartManager(shoppingCartRepository);

            var orders = appDbContext.Orders.Include(x => x.User).ToList();

            if (orders.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("\n=== Orders ===");

                foreach (var order in orders)
                    Console.WriteLine($"ID: {order.Id,5}, User: {order.User.FullName,20}, Status: {order.Status,20}");


            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nOrder not found.\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
