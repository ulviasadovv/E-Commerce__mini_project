using ECommerce.Domain.Entities.Core;

namespace ECommerce.Domain.Entities.Models;

public class Category : Entity
{
    public string Name { get; set; } = null!;
    public List<Product>? Products { get; set; } = [];
}