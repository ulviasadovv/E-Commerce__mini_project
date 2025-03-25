using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities.Models;

namespace ECommerce.Application.Extensions;

public static class OrderMapExtensions
{
    public static Order ToOrder(this OrderCreateDto orderCreateDto)
    {
        return new Order
        {
            UserId = orderCreateDto.UserId,
            Amount = orderCreateDto.Amount,
            Status = orderCreateDto.Status,
        };
    }

    public static OrderDto ToOrderDto(this Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            Status = order.Status,
            OrderDate = order.CreatedAt,
            Items = order.Items.Select(x => x.toOrderItemDto()).ToList(),
            User = order.User.ToUserDto(),
        };
    }
}
