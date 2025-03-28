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
        //Console.Clear();
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
            Console.WriteLine($"{"Products", 30}");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"{"ID", 5}, {"Name", 20} {"Price", 20}");
            Console.WriteLine(new string('=', 50));

            foreach (var product in products)
            {
                Console.WriteLine($"|| {product.Id,2} {product.Name,20} {product.Price,20} ||");
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
                            int quantity;

                            while (true)
                            {
                                bool isValid = true;

                                Console.WriteLine("Enter product quantity: ");
                                quantity = Convert.ToInt32(Console.ReadLine());

                                if (quantity <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Quantity must be greater than 0.");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    isValid = false;
                                }

                                if (isValid) break;
                            }

                            var orderItem = new OrderItemCreateDto
                            {
                                ProductId = selectedProduct.Id,
                                Quantity = quantity,
                            };

                            IShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository(appDbContext);
                            IShoppingCartService shoppingCartService = new ShoppingCartManager(shoppingCartRepository);
                            shoppingCartService.AddItem(orderItem, user.Id);

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
