namespace ECommerce.Domain.Entities
{
    public class User : Entity
    {
        public string FullName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal Balance { get; set; }
        public UserType UserType { get; set; }
        public List<Order>? Orders { get; set; } = [];
    }
}
