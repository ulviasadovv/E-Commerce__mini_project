using ECommerce.Application.DTOs;
using ECommerce.Application.Extensions;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities.Models;
using ECommerce.Domain.Interfaces;

namespace ECommerce.Application.Services
{
    public class ShoppingCartManager : IShoppingCartService
    {
        private readonly IShoppingCartRepository _repository;

        public ShoppingCartManager(IShoppingCartRepository repository)
        {
            _repository = repository;
        }

        public void AddItem(OrderItemCreateDto orderItemCreateDto, int userId)
        {
            var orderItem = orderItemCreateDto.toOrderItem();
            var shoppingCart = new ShoppingCart
            {
                OrderItems = new List<OrderItem> { orderItem },
                UserId = userId,
            };

            _repository.Add(shoppingCart);
        }

        public void ClearCart()
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
