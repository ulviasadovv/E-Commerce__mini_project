using ECommerce.Application.Interfaces;

namespace ECommerce.UI
{
    internal class OrderUI
    {
        public static async void PlaceOrder()
        {
            Console.Clear();
            var productService = Program.ServiceProvider.GetRequiredService<IProductService>();
            var orderService = Program.ServiceProvider.GetRequiredService<IOrderService>();

            var products = await productService.GetAllProductsAsync();
            if (!products.Any())
            {
                Console.WriteLine("Sipariş verilecek ürün bulunamadı.");
                return;
            }

            Console.WriteLine("=== Products ===");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }

            Console.Write("Enter quantity of products: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("Quantity is incorrect!");
                return;
            }

            //var orderDto = new OrderDto
            //{
            //    Id = 1, // Varsayılan müşteri ID, gerçekte giriş yapan kullanıcının ID'si olmalı
            //    Items = productId,
            //    Quantity = quantity
            //};

            //await orderService.PlaceOrderAsync(orderDto);
            Console.WriteLine("Sipariş başarıyla oluşturuldu!");
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

    }
}
