using E_commerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Abstracts
{
    public interface IproductService
    {

        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> CreateProductAsync(Product  product);

        Task<Product> GetByIdAsync(Guid id);
        Task<string> UpdateProductAsync(Product product);
        Task<string> DeleteProductAsync(Product product);
    }
}
