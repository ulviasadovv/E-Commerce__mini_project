using ECommerce.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.EfCore.Context;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=HP;Database=Pb304Ecommerce;Trusted_Connection=True;TrustServerCertificate=True");
    }
}
