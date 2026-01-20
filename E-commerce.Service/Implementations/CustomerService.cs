using E_commerce.Entities;
using E_commerce.Infrastructure.Abstractes;
using E_commerce.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        public Task<Customer> CreateProductAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteProductAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            var CustomerFromDb= await _customerRepository.GetByIdAsync(id); 

            return CustomerFromDb;
        }

        public Task<string> UpdateProductAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
