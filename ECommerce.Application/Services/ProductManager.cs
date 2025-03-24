using ECommerce.Application.DTOs;
using ECommerce.Application.Extensions;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities.Models;
using ECommerce.Domain.Interfaces;
using System.Linq.Expressions;

namespace ECommerce.Application.Services
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductManager(IProductRepository repository)
        {
            _repository = repository;
        }

        public void Add(ProductCreateDto productCreateDto)
        {
            var product = productCreateDto.toProduct();

            _repository.Add(product);
        }

        public ProductDto Get(Expression<Func<Product, bool>> predicate)
        {
            var product = _repository.Get(predicate);

            var productDto = product.toProductDto();

            return productDto;
        }

        public List<ProductDto> GetAll(Expression<Func<Product, bool>>? predicate, bool asNoTracking)
        {
            var products = _repository.GetAll(predicate, asNoTracking);

            var productDtoList = new List<ProductDto>();

            foreach (var product in products)
            {
                productDtoList.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                });
            }

            return productDtoList;
        }

        public ProductDto GetById(int id)
        {
            var product = _repository.GetById(id);

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId
            };

            return productDto;
        }

        public void Remove(int id)
        {
            var existEntity = _repository.GetById(id);

            if (existEntity == null) throw new Exception("Not found");

            _repository.Remove(existEntity);
        }

        public void Update(ProductUpdateDto productUpdateDto)
        {
            var product = new Product
            {
                Id = productUpdateDto.Id,
                Name = productUpdateDto.Name,
                Price = productUpdateDto.Price,
                CategoryId = productUpdateDto.CategoryId
            };

            _repository.Update(product);
        }
    }
}
