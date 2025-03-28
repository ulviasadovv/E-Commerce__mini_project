using ECommerce.Domain.Entities.Core;

namespace ECommerce.Domain.Entities.Models
{
    public class OrderItem : Entity
    {
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
