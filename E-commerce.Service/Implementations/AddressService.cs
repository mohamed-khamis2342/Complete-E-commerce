using E_commerce.Entities;
using E_commerce.Infrastructure.Abstractes;
using E_commerce.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Implementations
{
    public class AddressService:IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            
        }

        public async Task<string> CreateAddressAsync(Address address)
        {
            
            if (address == null)
                return   "something went wrong";

           await _addressRepository.AddAsync(address);

            return string.Empty;

        }

        public async Task<IEnumerable<Address>> GetAllAddresssAsync()
        {
           return await _addressRepository.GetAllAsync();
        }

       public async  Task<Address> GetByIdAsync(int id)
        {
            var Address = await _addressRepository.GetByIdAsync(id);    

            return Address;

        }
    }
}
