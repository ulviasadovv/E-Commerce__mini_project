using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities.Models;
using System.Linq.Expressions;

namespace ECommerce.Application.Interfaces
{
    public interface IOrderService
    {
        OrderDto GetById(int id);
        OrderDto Get(Expression<Func<Order, bool>> predicate);
        List<OrderDto> GetAll(Expression<Func<Order, bool>>? predicate, bool asNoTracking);
        public void Add(OrderCreateDto orderCreateDto);
        public void Update(OrderUpdateDto orderUpdateDto);
        public void Remove(int id);
        public void PlaceOrder(OrderDto orderDto);
    }
}
