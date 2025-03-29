using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities.Models;

namespace ECommerce.UI;

public class ProductUI
{
    private readonly IProductService _productService;
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IOrderService _orderService;

    public ProductUI(IProductService productService, IShoppingCartService shoppingCartService, IOrderService orderService)
    {
        _productService = productService;
        _shoppingCartService = shoppingCartService;
        _orderService = orderService;
    }

    public void ShowProducts(User user)
    {
        Console.Clear();
        var products = _productService.GetAll(null, false);

        if (!products.Any())
        {
            PrintMessage("Product not found!", ConsoleColor.Red);
            return;
        }

        DisplayProducts(products);
        HandleUserActions(user);
    }

    private void DisplayProducts(IEnumerable<ProductDto> products)
    {
        Console.WriteLine($"{"Products",30}");
        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"{"ID",5} {"Name",20} {"Price",20}");
        Console.WriteLine(new string('=', 50));

        foreach (var product in products)
        {
            Console.WriteLine($"|| {product.Id,2} {product.Name,20} {product.Price,20} ||");
        }

        Console.WriteLine("\n1. Add to basket");
        Console.WriteLine("2. Confirm basket");
        Console.WriteLine("3. Exit");
    }

    private void HandleUserActions(User user)
    {
        while (true)
        {
            Console.Write("\nChoose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProductToBasket(user);
                    break;
                case "2":
                    ConfirmBasket(user);
                    break;
                case "3":
                    return;
                default:
                    PrintMessage("Incorrect selection!", ConsoleColor.Red);
                    break;
            }
        }
    }

    private void AddProductToBasket(User user)
    {
        while (true)
        {
            Console.Write("Enter product ID (press \"0\" to exit): ");
            if (!int.TryParse(Console.ReadLine(), out int productId) || productId == 0)
                break;

            var selectedProduct = _productService.GetById(productId);
            if (selectedProduct == null)
            {
                PrintMessage("Product not found.", ConsoleColor.Red);
                continue;
            }

            int quantity = GetValidQuantity();
            var orderItem = new OrderItemCreateDto
            {
                ProductId = selectedProduct.Id,
                Quantity = quantity,
            };

            _shoppingCartService.AddItem(orderItem, user.Id);
            PrintMessage("Product added to basket.", ConsoleColor.Green);
        }
    }

    private int GetValidQuantity()
    {
        int quantity;
        while (true)
        {
            Console.Write("Enter product quantity: ");
            if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                return quantity;

            PrintMessage("Quantity must be greater than 0!", ConsoleColor.Red);
        }
    }

    private void ConfirmBasket(User user)
    {
        var cartItems = _shoppingCartService.GetAllItems(x => x.UserId == user.Id, false);
        decimal totalPrice = cartItems.Sum(cart => cart.OrderItems.Sum(item => item.Quantity * item.Product.Price));

        if (!cartItems.Any())
        {
            PrintMessage("Your basket is empty!", ConsoleColor.Red);
            return;
        }

        var orderItems = cartItems.SelectMany(x => x.OrderItems)
            .Select(x => new OrderItemDto
            {
                ProductId = x.Product.Id,
                Quantity = x.Quantity,
            })
            .ToList();

        var newOrder = new OrderCreateDto
        {
            UserId = user.Id,
            Amount = totalPrice,
            Items = orderItems,
        };

        _orderService.Add(newOrder);
        PrintMessage("Basket confirmed.", ConsoleColor.Green);
    }

    private void PrintMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"\n{message}\n");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}
