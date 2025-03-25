using ECommerce.Application.DTOs;
using ECommerce.Application.Extensions;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities.Models;
using ECommerce.Domain.Interfaces;
using System.Linq.Expressions;

namespace ECommerce.Application.Services;

public class OrderManager : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderManager(IOrderRepository repository)
    {
        _repository = repository;
    }

    public void Add(OrderCreateDto orderCreateDto)
    {
        var order = orderCreateDto.ToOrder();
        _repository.Add(order);
    }

    public void Update(OrderUpdateDto orderUpdateDto)
    {
        var order = new Order
        {
            Id = orderUpdateDto.Id,
        };

        _repository.Update(order);
    }

    public void Remove(int id)
    {
        var existEntity = _repository.GetById(id);

        if (existEntity == null) throw new Exception("Not found");

        _repository.Remove(existEntity);
    }

    public OrderDto GetById(int id)
    {
        var order = _repository.GetById(id);

        var orderDto = new OrderDto
        {
            Id = order.Id,
            Status = order.Status,
            //OrderDate = order.OrderDate,
            Items = order.Items.Select(i => new OrderItemDto
            {
                Id = i.Id,
                Product = new ProductDto
                {
                    Id = i.Product.Id,
                    Name = i.Product.Name,
                    Price = i.Product.Price,
                    CategoryId = i.Product.CategoryId,
                },
                Quantity = i.Quantity,
            }).ToList(),
            User = new UserDto
            {
                Id = order.User.Id,
                FullName = order.User.FullName,
                Balance = order.User.Balance,
            },
        };

        return orderDto;
    }

    public OrderDto Get(Expression<Func<Order, bool>> predicate)
    {
        var order = _repository.Get(predicate);

        var orderDto = order.ToOrderDto();

        return orderDto;
    }

    public List<OrderDto> GetAll(Expression<Func<Order, bool>>? predicate, bool asNoTracking)
    {
        var orders = _repository.GetAll(predicate, asNoTracking);

        var orderDtoList = new List<OrderDto>();

        foreach (var item in orders)
        {
            orderDtoList.Add(new OrderDto
            {
                Id = item.Id,
                Status = item.Status,
                //OrderDate = item.OrderDate,
                Items = item.Items.Select(i => new OrderItemDto
                {
                    Id = i.Id,
                    Product = new ProductDto
                    {
                        Id = i.Product.Id,
                        Name = i.Product.Name,
                        Price = i.Product.Price,
                    },
                    Quantity = i.Quantity,
                }).ToList(),
            });
        }

        return orderDtoList;
    }

    public void PlaceOrder(OrderDto orderDto)
    {
    }
}
