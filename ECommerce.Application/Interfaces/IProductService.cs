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
        public void Add(ProductCreateDto productCreateDto);
        public void Update(ProductUpdateDto productUpdateDto);
        public void Remove(int id);
    }
}
