using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;

namespace ECommerce.UI
{
    public class ProductUI
    {
        public static void ShowProducts()
        {
            Console.Clear();
            var productService = new ProductManager();
            var products = productService.GetAll();

            if (!products.Any())
            {
                Console.WriteLine("Product not found.");
            }
            else
            {
                Console.WriteLine("=== Products ===");
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
