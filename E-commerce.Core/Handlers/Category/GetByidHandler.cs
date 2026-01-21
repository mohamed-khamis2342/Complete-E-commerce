using E_commerce.Core.DTOs.Category;
using E_commerce.Core.Queries.Category;
using E_commerce.Core.Sources;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Category
{
    public class GetByidHandler : IRequestHandler<GetCategoryByIdQuery, ApiResponse<CategoryResponseDTO>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<SharedSource> _stringLocalizer;

        public GetByidHandler(ICategoryService categoryService, IStringLocalizer<SharedSource> stringLocalizer)
        {
            this._categoryService = categoryService;
            _stringLocalizer = stringLocalizer;
        }
        public async Task<ApiResponse<CategoryResponseDTO>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var categoryFromDB = await _categoryService.GetByIdAsync(request.Id);
            if (categoryFromDB == null)
                return new ApiResponse<CategoryResponseDTO>(400, _stringLocalizer[SharedSourceKey.NotFound]);

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
