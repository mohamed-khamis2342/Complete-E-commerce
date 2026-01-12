using E_commerce.Core.Commends.Address;
using E_commerce.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Address
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommend, string>
    {
        private readonly IAddressService _addressService;

        public DeleteAddressHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }


        public async Task<string> Handle(DeleteAddressCommend request, CancellationToken cancellationToken)
        {
            var DeletedAddress = new Entities.Address
            {
                Id= request.AddressId,
                CustomerId= request.CustomerId,
            };



            var result = await _addressService.DeleteAddressAsync(DeletedAddress);

            if(!string.IsNullOrEmpty(result))
                return result;

            return "Deleted Successfully";
        }
    }
}
