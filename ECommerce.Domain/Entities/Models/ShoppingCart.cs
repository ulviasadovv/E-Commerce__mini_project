using ECommerce.Domain.Entities.Core;

namespace ECommerce.Domain.Entities.Models
{
    public class ShoppingCart : Entity
    {
        public User User { get; set; } = null!;
        public List<Product> Products { get; set; } = null!;
    }
}
