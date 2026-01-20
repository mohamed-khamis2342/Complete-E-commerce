using E_commerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Abstracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> CreateProductAsync(Customer customer);

        Task<Customer> GetByIdAsync(Guid id);
        Task<string> UpdateProductAsync(Customer customer);
        Task<string> DeleteProductAsync(Customer customer);
    }
}
