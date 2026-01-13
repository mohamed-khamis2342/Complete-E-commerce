using E_commerce.Core.DTOs.Product;
using E_commerce.Core.Queries.Product;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Product
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<ProductResponseDTO>>
    {
        private readonly IproductService _iproductService;

        public GetProductByIdHandler(IproductService iproductService)
        {
            this._iproductService = iproductService;
        }
        public async Task<ApiResponse<ProductResponseDTO>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            
            var ProductFromDb = await _iproductService.GetByIdAsync(request.Id);
            if (ProductFromDb == null)
                return new ApiResponse<ProductResponseDTO>(400,"Id is wrong");


            var responce = new ProductResponseDTO
            {
                Id = ProductFromDb.Id,
                Description = ProductFromDb.Description,
                DiscountPercentage = ProductFromDb.DiscountPercentage,
                ImageUrl = ProductFromDb.ImageUrl,
                CategoryId = ProductFromDb.CategoryId,
                IsAvailable = ProductFromDb.IsAvailable,
                Name = ProductFromDb.Name,
                Price   = ProductFromDb.Price,
                StockQuantity   = ProductFromDb.StockQuantity,


            };


            return new ApiResponse<ProductResponseDTO>
            {
                StatusCode=200,
                Success= true,
                Data = responce

            };

        }
    }
}
