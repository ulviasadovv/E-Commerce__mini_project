using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Domain.Entities.Models;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore.Context;
using ECommerce.Infrastructure.EfCore;
using ECommerce.Application.DTOs;

namespace ECommerce.UI
{
    public class AdminMenu
    {
        public static void ShowAdminMenu(User user)
        {
                Console.Clear();

            while (true)
            {
                Console.WriteLine($"Welcome to admin panel {user.FullName}!");
                Console.WriteLine("\n1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Show Products");

                Console.WriteLine("\n5. Add Category");
                Console.WriteLine("6. Update Category");
                Console.WriteLine("7. Delete Category");
                Console.WriteLine("8. Show Categories");

                Console.WriteLine("\n9. Update Order");
                Console.WriteLine("10. Show Orders");

                Console.WriteLine("\n11. Exit");

                Console.Write("\nChoose an option: ");
                var choice = Console.ReadLine();
                Console.Clear();

                var appDbContext = new AppDbContext();
                IProductRepository productRepository = new ProductRepository(appDbContext);
                IProductService productService = new ProductManager(productRepository);
                var products = productService.GetAll(null, false);

                switch (choice)
                {
                    case "1":
                        while (true)
                        {
                            string name;

                            while (true)
                            {
                                Console.Write("Enter product name: ");
                                name = Console.ReadLine().Trim();

                                if (name == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nName cannot be empty!\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                }

                                bool isExist = false;

                                foreach (var prod in products)
                                {
                                    if (prod.Name.ToLower() == name.ToLower())
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\nProduct with this name already exists!\n");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        isExist = true;
                                        break;
                                    }
                                }

                                if (!isExist) break;
                            }

                            decimal price;

                            while (true)
                            {
                                Console.Write("Enter product price: ");
                                price = Convert.ToDecimal(Console.ReadLine());
                                bool isFalse = false;

                                if (price <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nPrice cannot be less than or equal to 0!\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    isFalse = true;
                                }

                                if(!isFalse) break;
                            }

                            int categoryId;

                            while (true)
                            {
                                Console.Write("Enter category ID: ");
                                categoryId = Convert.ToInt32(Console.ReadLine());
                                bool isFalse = false;

                                if (categoryId <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nCategory ID cannot be less than or equal to 0!\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    isFalse = true;
                                    break;
                                }

                                bool isExist = false;

                                foreach (var prod in products)
                                {
                                    if(prod.CategoryId == categoryId)
                                    {
                                        isExist = true;
                                        break;
                                    }
                                }

                                if(!isExist)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nCategory with this ID does not exist!\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    isFalse = true;
                                }

                                if (!isFalse) break;
                            }

                            var product = new ProductCreateDto
                            {
                                Name = name,
                                Price = price,
                                CategoryId = categoryId
                            };

                            productService.Add(product);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Product added successfully!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        }
                        break;
                    case "2":
                        while (true)
                        {
                            bool isExist = true;
                            Console.WriteLine("Enter product ID: ");
                            int productId = Convert.ToInt32(Console.ReadLine());
                            ProductDto? selectedProduct = null;

                            try
                            {
                                selectedProduct = productService.GetById(productId);
                            }
                            catch (Exception err)
                            {
                            }

                            if (selectedProduct == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nProduct with this ID is not exist!\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                isExist = false;
                            }

                            if (isExist) break;
                        }

                        while (true)
                        {
                            Console.WriteLine("Enter new product name: ");
                            string newName = Console.ReadLine().Trim();

                            if (newName == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nName cannot be empty!\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            }

                            foreach (var prod in products)
                            {
                                if (prod.Name.ToLower() == newName.ToLower())
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nProduct with this name already exists!\n");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                }
                            }
                        }

                        Console.WriteLine("Enter new product price: ");
                        decimal newPrice = Convert.ToDecimal(Console.ReadLine());

                        break;
                    case "3":
                        break;
                    case "11":
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
