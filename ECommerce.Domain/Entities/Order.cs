namespace ECommerce.Domain.Entities
{
    public class Order : Entity
    {
        public decimal Amount { get; set; }
        public StatusType Status { get; set; }
        public DateTime? OrderDate { get; set; } = DateTime.Now;
        public List<OrderItem> Items { get; set; } = [];
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
