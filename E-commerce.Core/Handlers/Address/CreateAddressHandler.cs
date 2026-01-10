using E_commerce.Core.Commends.Address;
using E_commerce.Core.DTOs.Address;
using E_commerce.DTOs;
using E_commerce.Entities;
using E_commerce.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Address
{
    public class CreateAddressHandler : IRequestHandler<CreateAddressCommend, ApiResponse<AddressResponseDTO>>
    {
        private readonly IAddressService _addressService;
        public CreateAddressHandler(IAddressService addressService)
        {
            _addressService = addressService;
        
            
        }
        public async Task<ApiResponse<AddressResponseDTO>> Handle(CreateAddressCommend request, CancellationToken cancellationToken)
        {

            var CreateAddress = new Entities.Address
            {   CustomerId=request.CustomerId,
                City = request.City,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                Country = request.Country,
                PostalCode = request.PostalCode,
                State = request.State,
            };
        var result = await _addressService.CreateAddressAsync(CreateAddress);

            if (!string.IsNullOrEmpty(result))
            {
                return new ApiResponse<AddressResponseDTO>(400, "Something went wrong");

            }
            var response = new AddressResponseDTO
            {
               
                City = request.City,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                Country = request.Country,
                PostalCode = request.PostalCode,
                State = request.State,

            };
           

            return new ApiResponse<AddressResponseDTO>()
            { StatusCode=200,
            Success=true,
            Data = response
            };

        }
    }
}
