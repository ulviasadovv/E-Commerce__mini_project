using ECommerce.Domain.Entities.Models;

namespace ECommerce.UI
{
    public class Menu
    {
        public static void ShowMainMenu(User user)
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

                switch (choice)
                {
                    case "1":
                        ProductUI.ShowProducts(user);
                        break;
                    case "2":
                        OrderUI.PlaceOrder(user);
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
