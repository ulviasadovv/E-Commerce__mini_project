using ECommerce.Domain.Entities.Models;

namespace ECommerce.Application.DTOs;

public class ShoppingCartDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required User User { get; set; }
    public required List<OrderItem> OrderItems { get; set; }
}

public class ShoppingCartCreateDto
{
    public int UserId { get; set; }
    public required User User { get; set; }
    public required List<OrderItem> OrderItems { get; set; }
}

public class ShoppingCartUpdateDto
{
    public int? Id { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }
    public List<OrderItem>? OrderItems { get; set; }
}
