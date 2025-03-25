using ECommerce.Domain.Entities.Models;

namespace ECommerce.Application.DTOs;

public class ShoppingCartDto
{
    public int Id { get; set; }
    public required User User { get; set; }
    public required List<Product> Products { get; set; }
}

public class ShoppingCartCreateDto
{
    public required User User { get; set; }
    public required List<Product> Products { get; set; }
}

public class ShoppingCartUpdateDto
{
    public int? Id { get; set; }
    public User? User { get; set; }
    public List<Product>? Products { get; set; }
}
