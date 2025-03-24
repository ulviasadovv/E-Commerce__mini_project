using ECommerce.Infrastructure.EfCore.Context;

namespace ECommerce.UI
{
    public class Authentication
    {
        public static void Login()
        {
            var dbContext = new AppDbContext();

            Console.Clear();
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            var user = dbContext.Users.FirstOrDefault(u => u.FullName == username && u.Password == password);

            if (user != null)
            {
                Console.WriteLine($"Welcome {user.FullName}!");
            }
            else
            {
                Console.WriteLine("Username or password is not correct!");
            }

            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();
        }

    }
}
