using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Domain.Entities.Models;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore.Context;
using ECommerce.Infrastructure.EfCore;

namespace ECommerce.UI
{
    public class Menu
    {
        public static void ShowMainMenu(IProductService productService, IShoppingCartService shoppingCartService, IOrderService orderService, User user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome {user.FullName}!");
                Console.WriteLine("\n1. Show Products");
                Console.WriteLine("2. Order");
                Console.WriteLine("3. Exit");

                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                var productUI = new ProductUI(productService, shoppingCartService, orderService);

                switch (choice)
                {
                    case "1":
                        productUI.ShowProducts(user);
                        break;
                    case "2":
                        OrderUI.PlaceOrder();
                        break;
                    case "3":
                        Console.WriteLine("Goodbye...");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nIncorrect selection!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }
        }
    }
}
