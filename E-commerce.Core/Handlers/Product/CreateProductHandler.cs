using E_commerce.Core.Commends.Product;
using E_commerce.Core.DTOs.Product;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Product
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommend, ApiResponse<ProductResponseDTO>>
    {
        private readonly IproductService _iproductService;

        public CreateProductHandler(IproductService iproductService)
        {
            this._iproductService = iproductService;
        }
        public async Task<ApiResponse<ProductResponseDTO>> Handle(CreateProductCommend request, CancellationToken cancellationToken)
        {
            if (request.StockQuantity == 0)
            {
                return new ApiResponse<ProductResponseDTO>(400,"Stock is Zero");   
             
            }
            var AddProduct = new Entities.Product()
            {
                Name = request.Name,
                Description = request.Description,
                DiscountPercentage = request.DiscountPercentage,
                CategoryId = request.CategoryId,
                ImageUrl = request.ImageUrl,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                IsAvailable = true,
            };
           
        

            var result = await _iproductService.CreateProductAsync(AddProduct);

            if (result == null) {

                return new ApiResponse<ProductResponseDTO>(400, "Something went  Wrong");
            }
            var response = new ProductResponseDTO()
            {
                Id = result.Id,
                Name = result.Name,
                CategoryId= result.CategoryId,
                ImageUrl = result.ImageUrl,
                Description= result.Description,
                DiscountPercentage= result.DiscountPercentage,
                Price= result.Price,
                IsAvailable= result.IsAvailable,
                StockQuantity= result.StockQuantity,

            };



            return new ApiResponse<ProductResponseDTO>
            {
                StatusCode = 200,   
                Success = true, 
                Data = response

            };

        }
    }
}
