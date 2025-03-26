using ECommerce.Domain.Entities.Models;

namespace ECommerce.UI
{
    public class AdminMenu
    {
        public static void ShowAdminMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Products");
                Console.WriteLine("2. Show Orders");
                Console.WriteLine("3. Add User");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "4":
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
