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
            AppDbContext appDbContext = new AppDbContext();

            ICategoryRepository categoryRepository = new CategoryRepository(appDbContext);
            ICategoryService categoryService = new CategoryManager(categoryRepository);

            IProductRepository productRepository = new ProductRepository(appDbContext);
            IProductService productService = new ProductManager(productRepository);

            IUserRepository userRepository = new UserRepository(appDbContext);
            IUserService userService = new UserManager(userRepository);

            //categoryService.Add(new CategoryCreateDto { Name = "Fruit" });
            //categoryService.Add(new CategoryCreateDto { Name = "Vegetables" });
            //userService.Add(new UserCreateDto { FullName = "Samir", Password = "0000"});
        }
    }
}
