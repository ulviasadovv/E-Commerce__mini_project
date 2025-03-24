using ECommerce.Domain.Entities.Core;
using ECommerce.Domain.Entities.Enums;

namespace ECommerce.Domain.Entities.Models
{
    public class User : Entity
    {
        public string FullName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal Balance { get; set; }
        public UserType Type { get; set; }
        public List<Order>? Orders { get; set; } = [];
    }
}
