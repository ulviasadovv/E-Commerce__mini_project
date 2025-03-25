using ECommerce.Domain.Entities.Enums;
using ECommerce.Infrastructure.EfCore.Context;

namespace ECommerce.UI
{
    public class Authentication
    {
        public static void Login()
        {
            var dbContext = new AppDbContext();

            Console.WriteLine("=== E-Commerce Application ===");
            Console.WriteLine();
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            var user = dbContext.Users.FirstOrDefault
                (
                u => u.FullName.ToLower() == username.ToLower() &&
                u.Password.ToLower() == password.ToLower()
                );

            if (user != null)
            {
                if (user.Type == UserType.Admin)
                {
                    Console.WriteLine($"\nWelcome Admin {user.FullName}!");
                    AdminMenu.ShowAdminMenu();
                }
                else
                {
                    Console.WriteLine($"\nWelcome {user.FullName}!");
                    Menu.ShowMainMenu(user);
                    return;
                }
            }
            else
                Console.WriteLine("Username or password is not correct!");
        }

    }
}
