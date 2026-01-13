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
    public class GetByidHandler : IRequestHandler<GetCategoryByIdQuery, ApiResponse<CategoryResponseDTO>>
    {
        private readonly ICategoryService _categoryService;

        public GetByidHandler(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public async Task<ApiResponse<CategoryResponseDTO>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var categoryFromDB = await _categoryService.GetByIdAsync(request.Id);
            if (categoryFromDB == null)
                return new ApiResponse<CategoryResponseDTO>(400,"Not Found");

            var Responce = new CategoryResponseDTO
            {
                Id = categoryFromDB.Id,
                Description=categoryFromDB.Description, 
                Name = categoryFromDB.Name,
                IsActive = categoryFromDB.IsActive,

            };

            return new ApiResponse<CategoryResponseDTO>()
            {
                StatusCode = 200,
                Success = true,
                Data = Responce


            };

        }
    }
}
