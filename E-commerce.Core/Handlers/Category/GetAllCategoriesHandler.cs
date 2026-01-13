using E_commerce.Core.DTOs.Category;
using E_commerce.Core.Queries.Category;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Category
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, ApiResponse<List<CategoryResponseDTO>>>
    {
        private readonly ICategoryService _categoryService;

        public GetAllCategoriesHandler(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public async Task<ApiResponse<List<CategoryResponseDTO>>> Handle(
       GetAllCategoriesQuery request,
       CancellationToken cancellationToken)
        {
            var categoriesFromDB = await _categoryService.GetAllCategoryAsync();

            if (categoriesFromDB == null || !categoriesFromDB.Any())
            {
                return new ApiResponse<List<CategoryResponseDTO>>
                {
                    StatusCode = 200,
                    Success = true,
                    Data = new List<CategoryResponseDTO>()
                };
            }

            var categories = categoriesFromDB.Select(category => new CategoryResponseDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive
            }).ToList();

            return new ApiResponse<List<CategoryResponseDTO>>
            {
                StatusCode = 200,
                Success = true,
                Data = categories
            };
        }

    }
}
