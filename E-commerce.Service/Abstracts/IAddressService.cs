using E_commerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Abstracts
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAllAddresssAsync();
        Task<string> CreateAddressAsync(Address address);

        Task<Address> GetByIdAsync(Guid id);
        Task<string> UpdateAddressAsync(Address address);
        Task<string> DeleteAddressAsync(Address address);

      
    }
}
