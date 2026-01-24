using E_commerce.Core.DTOs.Category;
using E_commerce.Core.DTOs.Product;
using E_commerce.Core.Queries.Product;
using E_commerce.Core.SharedDTO;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using E_commerce.Service.Implementations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Product
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, ApiResponseFroPagination<List<ProductResponseDTO>>>
    {
        private readonly IproductService _productService;
        private readonly IPaginationService<Entities.Product> _paginationService;

        public GetAllProductsHandler(IproductService productService,
            IPaginationService<Entities.Product> paginationService
            )
        {
            this._productService = productService;
            this._paginationService = paginationService;
        }
        public async Task<ApiResponseFroPagination<List<ProductResponseDTO>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var AllProducts = await _productService.GetAllProductAsync();

           

            if (AllProducts == null || !AllProducts.Any())
            {
                return new ApiResponseFroPagination<List<ProductResponseDTO>>(200, "No products Found");
            }

            var PaginatedList = await _paginationService.PaginatedAsync(request.PageNumber, request.Pagesize, AllProducts.AsQueryable());

            var Products = PaginatedList.Select(product => new ProductResponseDTO
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

            return new ApiResponseFroPagination<List<ProductResponseDTO>>
            {

                StatusCode = 200,
                Success = true,
                PageNumber = request.PageNumber,
                PageSize = request.Pagesize,
                Data = Products
            };


        }
    }
}
