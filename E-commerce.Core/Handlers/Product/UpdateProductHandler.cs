using E_commerce.Core.Commends.Product;
using E_commerce.Core.DTOs.Product;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using E_commerce.Service.Implementations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Product
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommend, ApiResponse<string>>
    {
        private readonly IproductService _iproductService;
        private readonly ICategoryService _CategoryService;
        public UpdateProductHandler(IproductService iproductService, ICategoryService categoryService)
        {
            this._iproductService = iproductService;
            _CategoryService = categoryService;
        }


        public async Task<ApiResponse<string>> Handle(UpdateProductCommend request, CancellationToken cancellationToken)
        {
            var ProductFromDb = await _iproductService.GetByIdAsync(request.Id);
            if (ProductFromDb == null)
                return new ApiResponse<string>(400,"Id is not Valid");

            ProductFromDb.Id    = request.Id;
            ProductFromDb.Name = request.Name;
            ProductFromDb.Description = request.Description;
            ProductFromDb.Price = request.Price;
             ProductFromDb.DiscountPercentage       = request.DiscountPercentage;
            ProductFromDb.StockQuantity = request.StockQuantity;    

            var FindCategory = await _CategoryService.GetByIdAsync(request.CategoryId);
            if (FindCategory == null)
               return new ApiResponse<string>(400, "The category is not existed");

            ProductFromDb.CategoryId = request.CategoryId;
            if (request.StockQuantity == 0 )
            {
                ProductFromDb.IsAvailable = false;
               
            }
            ProductFromDb.IsAvailable = true;


            var result = await _iproductService.UpdateProductAsync(ProductFromDb);
            
            if (!string.IsNullOrEmpty(result))
                return new ApiResponse<string>
                {
                    StatusCode = 200,
                    Success = true,

                    Data = $"product with Id = {ProductFromDb.Id} Successfully"
                };

            return new ApiResponse<string>(400, "Something went wrong");


        }
    }
}
