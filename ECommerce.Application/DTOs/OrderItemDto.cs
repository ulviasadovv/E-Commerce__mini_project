namespace ECommerce.Application.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderDto Order { get; set; } = null!;
        public int ProductId { get; set; }
        public ProductDto Product { get; set; } = null!;
        public int Quantity { get; set; }
    }

    public class OrderItemCreateDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderItemUpdateDto
    {
        public int? OrderId { get; set; }
        public OrderDto? Order { get; set; }
        public int? ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int? Quantity { get; set; }
    }
}
