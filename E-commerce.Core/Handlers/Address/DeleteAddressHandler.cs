using E_commerce.Core.Commends.Address;
using E_commerce.Core.Sources;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Address
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommend, ApiResponse<string>>
    {
        private readonly IAddressService _addressService;
        private readonly IStringLocalizer<SharedSource> _stringLocalizer;

        public DeleteAddressHandler(IAddressService addressService,IStringLocalizer<SharedSource> stringLocalizer)
        {
            _addressService = addressService;
            this._stringLocalizer = stringLocalizer;
        }


        public async Task<ApiResponse<string>> Handle(DeleteAddressCommend request, CancellationToken cancellationToken)
        {
            var DeletedAddress = new Entities.Address
            {
                Id= request.AddressId,
                CustomerId= request.CustomerId,
            };



            var result = await _addressService.DeleteAddressAsync(DeletedAddress);

            if (!string.IsNullOrEmpty(result))
                return new ApiResponse<string> (400, _stringLocalizer[SharedSourceKey.Wrong]);


            return new ApiResponse<string>
            {
                StatusCode =200,
                Success = true,
                Data = _stringLocalizer[SharedSourceKey.Deleted],
            };
        }
    }
}
