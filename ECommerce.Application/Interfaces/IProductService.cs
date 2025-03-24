using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities.Models;
using System.Linq.Expressions;

namespace ECommerce.Application.Interfaces
{
    public interface IProductService
    {
        ProductDto GetById(int id);
        ProductDto Get(Expression<Func<Product, bool>> predicate);
        List<ProductDto> GetAll(Expression<Func<Product, bool>>? predicate, bool asNoTracking);
        public void Add(ProductCreateDto orderCreateDto);
        public void Update(ProductUpdateDto orderUpdateDto);
        public void Remove(int id);
    }
}
