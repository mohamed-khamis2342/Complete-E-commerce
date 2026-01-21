using E_commerce.Core.Commends.Address;
using E_commerce.Core.Sources;
using E_commerce.DTOs;
using E_commerce.Entities;
using E_commerce.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Address
{
    public class UpdateAddressHandler : IRequestHandler<UpdateAddressCommend, ApiResponse<string>>
    {
        private readonly IAddressService _addressService;
        private readonly IStringLocalizer<SharedSource> _stringLocalizer;
        public UpdateAddressHandler(IAddressService addressService, IStringLocalizer<SharedSource> stringLocalizer)
        {
            this._addressService = addressService;
            _stringLocalizer = stringLocalizer;
        }


        public async Task<ApiResponse<string>> Handle(UpdateAddressCommend request, CancellationToken cancellationToken)
        {
            var Address = new Entities.Address
            {
                Id = request.AddressId,
                CustomerId = request.CustomerId,    
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                City = request.City,
                Country = request.Country,
                PostalCode = request.PostalCode,
                State= request.State,

            };

            var result = await _addressService.UpdateAddressAsync(Address);

            if (string.IsNullOrEmpty(result))
                return new ApiResponse<string>(400, _stringLocalizer[SharedSourceKey.Wrong]);


            return  new ApiResponse<string> { StatusCode=200,
              Success =true,
              Data = result 
            
            };

          
        }
    }
}
