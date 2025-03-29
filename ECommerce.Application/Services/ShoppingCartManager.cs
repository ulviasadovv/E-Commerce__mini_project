using ECommerce.Application.DTOs;
using ECommerce.Application.Extensions;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities.Models;
using ECommerce.Domain.Interfaces;
using System.Linq.Expressions;

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

        public void ClearCart(Expression<Func<ShoppingCart, bool>>? predicate = null, bool asNoTracking = false)
        {
            var shoppingCartItems = _repository.GetAll(predicate, asNoTracking);

            foreach (var item in shoppingCartItems)
            {
                _repository.Remove(item);
            }
        }

        public List<ShoppingCartDto> GetAllItems(Expression<Func<ShoppingCart, bool>>? predicate = null, bool asNoTracking = false)
        {
            var shoppingCartItems = _repository.GetAll(predicate, asNoTracking);
            var shoppingCartDtoList = new List<ShoppingCartDto>();

            foreach (var item in shoppingCartItems)
            {
                shoppingCartDtoList.Add(new ShoppingCartDto
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    User = item.User,
                    OrderItems = item.OrderItems
                });
            }

            return shoppingCartDtoList;
        }

        public decimal GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int Id)
        {
            var item = _repository.GetById(Id);

            _repository.Remove(item);
        }
    }
}
