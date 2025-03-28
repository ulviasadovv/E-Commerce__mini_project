using ECommerce.Domain.Entities.Core;

namespace ECommerce.Domain.Entities.Models
{
    public class ShoppingCart : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public List<OrderItem> OrderItems { get; set; } = null!;
    }
}
