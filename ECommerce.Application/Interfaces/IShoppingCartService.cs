using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities.Models;
using System.Linq.Expressions;

namespace ECommerce.Application.Interfaces
{
    public interface IShoppingCartService
    {
        public void AddItem(OrderItemCreateDto orderItem, int userId);
        public List<ShoppingCartDto> GetAllItems(Expression<Func<ShoppingCart, bool>>? predicate = null, bool asNoTracking = false);
        public void RemoveItem(int Id);
        public decimal GetTotalPrice();
        public void ClearCart(Expression<Func<ShoppingCart, bool>>? predicate = null, bool asNoTracking = false);
    }
}
