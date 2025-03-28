﻿using ECommerce.Domain.Entities.Enums;
using ECommerce.Infrastructure.EfCore.Context;

namespace ECommerce.UI
{
    public class Authentication
    {
        public static void Login()
        {
            var dbContext = new AppDbContext();

            Console.WriteLine("=== E-Commerce Application ===");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                var user = dbContext.Users.FirstOrDefault
                    (
                    u => u.FullName.ToLower() == username.ToLower() &&
                    u.Password == password
                    );

                if (user != null)
                {
                    if (user.Type == UserType.Admin)
                    {
                        AdminMenu.ShowAdminMenu(user);
                    }
                    else
                    {
                        Menu.ShowMainMenu(user);
                        return;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Username or password is not correct!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
