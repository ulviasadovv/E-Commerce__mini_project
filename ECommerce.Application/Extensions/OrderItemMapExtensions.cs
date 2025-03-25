using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities.Models;

namespace ECommerce.Application.Extensions
{
    public static class OrderItemMapExtensions
    {
        public static OrderItem toOrderItem (this OrderItemCreateDto orderItemCreateDto)
        {
            return new OrderItem
            {
                OrderId = orderItemCreateDto.OrderId,
                ProductId = orderItemCreateDto.ProductId,
                Quantity = orderItemCreateDto.Quantity
            };
        }

        public static OrderItemDto toOrderItemDto(this OrderItem orderItem)
        {
            return new OrderItemDto
            {
                Id = orderItem.Id,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity
            };
        }
    }
}
