using ECommerce.Domain.Entities.Core;

namespace ECommerce.Domain.Entities.Models
{
    internal class ShoppingCart : Entity
    {
        public List<OrderItem> Items { get; private set; } = [];

        public void AddItem(Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new OrderItem { ProductId = product.Id, Product = product, Quantity = quantity });
            }
        }

        public void RemoveItem(int productId)
        {
            Items.RemoveAll(i => i.ProductId == productId);
        }

        public decimal GetTotalPrice()
        {
            return Items.Sum(i => i.Product.Price * i.Quantity);
        }

        public void ClearCart()
        {
            Items.Clear();
        }
    }
}
