using E_commerce.Core.DTOs.Category;
using E_commerce.Core.DTOs.Product;
using E_commerce.Core.Queries.Product;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using E_commerce.Service.Implementations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Product
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, ApiResponse<List<ProductResponseDTO>>>
    {
        private readonly IproductService _productService;

        public GetAllProductsHandler(IproductService productService)
        {
            this._productService = productService;
        }
        public async Task<ApiResponse<List<ProductResponseDTO>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var AllProducts = await _productService.GetAllProductAsync();

           

            if (AllProducts == null || !AllProducts.Any())
            {
                return new ApiResponse<List<ProductResponseDTO>>(200, "No products Found");
            }

            var Products = AllProducts.Select(product => new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId,
                DiscountPercentage = product.DiscountPercentage,
                ImageUrl = product.ImageUrl,
                IsAvailable = product.IsAvailable,
                Price = product.Price,
              
            }).ToList();

            return new ApiResponse<List<ProductResponseDTO>>
            {
                StatusCode = 200,
                Success = true,
                Data = Products
            };


        }
    }
}
