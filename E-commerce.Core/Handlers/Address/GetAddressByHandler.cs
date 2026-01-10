using E_commerce.Core.DTOs.Address;
using E_commerce.Core.Queries.Address;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Address
{
    public class GetAddressByHandler : IRequestHandler<GetAddressByIdQuery, ApiResponse<AddressResponseDTO>>
    {
        private readonly IAddressService _addressService;

        public GetAddressByHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }
        public async Task<ApiResponse<AddressResponseDTO>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var AddressFromDb = await _addressService.GetByIdAsync(request.Id);

            if (AddressFromDb == null) {
                return new ApiResponse<AddressResponseDTO>(400, "Not found");
                    }

            var response = new AddressResponseDTO
            {
                Id= AddressFromDb.Id,
                CustomerId= AddressFromDb.CustomerId,
                City= AddressFromDb.City,
                Country= AddressFromDb.Country,
                AddressLine1= AddressFromDb.AddressLine1,
                AddressLine2= AddressFromDb.AddressLine2,
                State= AddressFromDb.State,
                PostalCode= AddressFromDb.PostalCode,

            };

            return new ApiResponse<AddressResponseDTO>()
            {
                StatusCode= 200,
                Success= true,  
                Data = response 
            };



          
        }
    }
}
