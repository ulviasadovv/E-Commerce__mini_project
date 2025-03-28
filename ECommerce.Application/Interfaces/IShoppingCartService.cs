using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities.Models;

namespace ECommerce.Application.Interfaces
{
    public interface IShoppingCartService
    {
        public void AddItem(OrderItemCreateDto orderItem, int userId);
        public void RemoveItem(int Id);
        public decimal GetTotalPrice();
        public void ClearCart();
    }
}
