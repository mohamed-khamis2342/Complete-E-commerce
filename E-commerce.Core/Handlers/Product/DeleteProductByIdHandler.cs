using E_commerce.Core.Commends.Product;
using E_commerce.Core.Sources;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Product
{
    public class DeleteProductByIdHandler : IRequestHandler<DeleteProductCommend, ApiResponse<string>>
    {
        private readonly IproductService _productService;
        private readonly IStringLocalizer<SharedSource> _stringLocalizer;


        public DeleteProductByIdHandler(IproductService productService, IStringLocalizer<SharedSource> stringLocalizer = null)
        {
            this._productService = productService;
            _stringLocalizer = stringLocalizer;
        }
        public async Task<ApiResponse<string>> Handle(DeleteProductCommend request, CancellationToken cancellationToken)
        {
            var productFromDb = await _productService.GetByIdAsync(request.id);

            if (productFromDb == null) 
                return new ApiResponse<string>(400,"Id is not Correct");

            productFromDb.IsAvailable = false;
            await _productService.UpdateProductAsync(productFromDb);    

            return new ApiResponse<string>
            {
                StatusCode = 200,
                Success = true,
                Data = $"Product {_stringLocalizer[SharedSourceKey.Deleted]}"
            };


        }
    }
}
