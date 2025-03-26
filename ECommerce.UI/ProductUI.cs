using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Domain.Entities.Models;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore;
using ECommerce.Infrastructure.EfCore.Context;

namespace ECommerce.UI;

public class ProductUI
{
    public static void ShowProducts(User user)
    {
        var appDbContext = new AppDbContext();
        IProductRepository productRepository = new ProductRepository(appDbContext);
        IProductService productService = new ProductManager(productRepository);
        var products = productService.GetAll(null, false);

        if (!products.Any())
        {
            Console.WriteLine("Product not found.");
        }
        else
        {
            Console.WriteLine("\n=== Products ===");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }

            Console.WriteLine("\n1. Add to basket");
            Console.WriteLine("2. Exit");
            while (true)
            {
                Console.Write("\nChoose an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter product ID: ");
                        var productId = Convert.ToInt32(Console.ReadLine());
                        var selectedProduct = productService.GetById(productId);
                        if (selectedProduct == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Product not found.");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            var order = new OrderCreateDto
                            {
                                UserId = user.Id,
                            };

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Product added to basket.");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    case "2":
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
