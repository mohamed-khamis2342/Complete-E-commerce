using E_commerce.Entities;
using E_commerce.Infrastructure.Abstractes;
using E_commerce.Infrastructure.Repository;
using E_commerce.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Implementations
{
    public class ProductService : IproductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
       public async Task<Product> CreateProductAsync(Product product)
        {
            var ProductAdded = await _productRepository.AddAsync(product);

            return ProductAdded;
        }

        public async Task<string> DeleteProductAsync(Product product)
        {
            var result = _productRepository.DeleteAsync(product);

            if (!result.IsCompleted)
                return "Delete Failed";
            return string.Empty;
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product>GetByIdAsync(Guid id)
        {
            var Product = await _productRepository.GetByIdAsync(id);

            return Product;
        }

        public async Task<string>UpdateProductAsync(Product product)
        {
            var result = _productRepository.UpdateAsync(product);

            if (!result.IsCompleted)
                return "Update failed";

            return string.Empty;
        }
    }
}
