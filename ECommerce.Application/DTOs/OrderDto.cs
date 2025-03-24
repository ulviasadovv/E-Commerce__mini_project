using ECommerce.Domain.Entities.Enums;

namespace ECommerce.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public StatusType Status { get; set; }
        public DateTime? OrderDate { get; set; } = DateTime.Now;
        public List<OrderItemDto>? Items { get; set; }
        public UserDto User { get; set; } = null!;
    }

    public class OrderCreateDto
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public StatusType Status { get; set; } = StatusType.Pending;
    }

    public class OrderUpdateDto
    {
        public int Id { get; set; }
        public StatusType Status { get; set; }
        public DateTime? OrderDate { get; set; } = DateTime.Now;
        public List<OrderItemDto>? Items { get; set; }
        public UserDto User { get; set; } = null!;
    }
}
