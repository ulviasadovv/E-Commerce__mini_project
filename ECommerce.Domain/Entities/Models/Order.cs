using ECommerce.Domain.Entities.Core;
using ECommerce.Domain.Entities.Enums;

namespace ECommerce.Domain.Entities.Models
{
    public class Order : Entity
    {
        public decimal Amount { get; set; }
        public StatusType Status { get; set; }
        public List<OrderItem> Items { get; set; } = [];
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
