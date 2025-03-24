using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities.Models;

namespace ECommerce.Application.Extensions;

public static class ProductMapExtensions
{
    public static Product toProduct(this ProductCreateDto product)
    {
        return new Product
        {
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId,
        };
    }

    public static ProductDto toProductDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId,
        };
    }
}
