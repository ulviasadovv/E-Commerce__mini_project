using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Services;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore;
using ECommerce.Infrastructure.EfCore.Context;

namespace ECommerce.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var appDbContext = new AppDbContext();

            ICategoryRepository categoryRepository = new CategoryRepository(appDbContext);
            ICategoryService categoryService = new CategoryManager(categoryRepository);

            IUserRepository userRepository = new UserRepository(appDbContext);
            IUserService userService = new UserManager(userRepository);

            IProductRepository productRepository = new ProductRepository(appDbContext);
            IProductService productService = new ProductManager(productRepository);

            IOrderRepository orderRepository = new OrderRepository(appDbContext);
            IOrderService orderService = new OrderManager(orderRepository);

            Authentication.Login();

            //productService.Add(new ProductCreateDto { Name = "Apple", Price = 1.2m, CategoryId = 1 });
            //productService.Add(new ProductCreateDto { Name = "Phone", Price = 800, CategoryId = 3 });
            //productService.Add(new ProductCreateDto { Name = "Orange", Price = 1.5m, CategoryId = 1 });
            //productService.Add(new ProductCreateDto { Name = "Carrot", Price = 0.5m, CategoryId = 2 });
            //productService.Add(new ProductCreateDto { Name = "Laptop", Price = 1200, CategoryId = 3 });
            //productService.Add(new ProductCreateDto { Name = "Cucumber", Price = 0.3m, CategoryId = 2 });

            //categoryService.Add(new CategoryCreateDto { Name = "Fruit" });
            //categoryService.Add(new CategoryCreateDto { Name = "Vegetables" });
            //categoryService.Add(new CategoryCreateDto { Name = "Electronics" });
        }
    }
}
