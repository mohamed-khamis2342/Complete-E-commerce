using E_commerce.Core.Commends.Address;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Address
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommend, ApiResponse<string>>
    {
        private readonly IAddressService _addressService;

        public DeleteAddressHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }


        public async Task<ApiResponse<string>> Handle(DeleteAddressCommend request, CancellationToken cancellationToken)
        {
            var DeletedAddress = new Entities.Address
            {
                Id= request.AddressId,
                CustomerId= request.CustomerId,
            };



            var result = await _addressService.DeleteAddressAsync(DeletedAddress);

            if (string.IsNullOrEmpty(result))
                return new ApiResponse<string> (400,result);


            return new ApiResponse<string>
            {
                StatusCode =200,
                Success = true,
                Data = "Deleted Successfully",
            };
        }
    }
}
