using E_commerce.Core.Commends.Product;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Product
{
    public class DeleteProductByIdHandler : IRequestHandler<DeleteProductCommend, ApiResponse<string>>
    {
        private readonly IproductService _productService;

        public DeleteProductByIdHandler(IproductService productService)
        {
            this._productService = productService;
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
                Data = "Product deleted successfully"
            };


        }
    }
}
