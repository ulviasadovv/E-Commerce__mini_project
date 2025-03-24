namespace ECommerce.UI
{
    public class Menu
    {
        public static void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== E-Commerce Application ===");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Show Products");
                Console.WriteLine("3. Order");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Authentication.Login();
                        break;
                    case "2":
                        ProductUI.ShowProducts();
                        break;
                    case "3":
                        OrderUI.PlaceOrder();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye...");
                        return;
                    default:
                        Console.WriteLine("Incorrect selection.");
                        break;
                }
            }
        }
    }
}
