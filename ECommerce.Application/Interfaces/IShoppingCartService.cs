using ECommerce.Application.DTOs;

namespace ECommerce.Application.Interfaces
{
    public interface IShoppingCartService
    {
        public void AddItem(OrderItemCreateDto orderItemCreateDto);
        public void RemoveItem(int Id);
        public decimal GetTotalPrice();
        public void ClearCart();
    }
}
