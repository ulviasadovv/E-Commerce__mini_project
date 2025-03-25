using ECommerce.Application.DTOs;
using ECommerce.Application.Extensions;
using ECommerce.Application.Interfaces;
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

        public void AddItem(OrderItemCreateDto createDto)
        {
            //var existingItem = createDto.toShoppingCart
            //if (existingItem != null)
            //{
            //    existingItem.Quantity += createDto.Quantity;
            //}
            //else
            //{
            //    var orderItem = createDto.toOrderItem();

            //    _repository.Add(orderItem);
            //}
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
