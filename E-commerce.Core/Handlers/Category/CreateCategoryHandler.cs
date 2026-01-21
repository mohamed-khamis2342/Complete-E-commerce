using E_commerce.Core.Commends.Category;
using E_commerce.Core.DTOs.Category;
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
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommend,ApiResponse<CategoryResponseDTO>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<SharedSource> _stringLocalizer;
        public CreateCategoryHandler(ICategoryService categoryService, IStringLocalizer<SharedSource> stringLocalizer)
        {
            _categoryService = categoryService;
            _stringLocalizer = stringLocalizer;
        }



        public async Task<ApiResponse<CategoryResponseDTO>> Handle(CreateCategoryCommend request, CancellationToken cancellationToken)
        {
            var Category = new Entities.Category
            {
                Description = request.Description,
                Name = request.Name
            };

            var result = await _categoryService.CreateCategoryAsync(Category);

            if (result is not null)
            {

                var response = new CategoryResponseDTO
                {
                    Id= result.Id,
                 Name = request.Name,
                 Description = result.Description,
                 IsActive = result.IsActive,

                };
                return new ApiResponse<CategoryResponseDTO>()
             
                {
                    StatusCode=200,
                    Success=true,
                    Data = response

                };
            }

            return new ApiResponse<CategoryResponseDTO>(400, _stringLocalizer[SharedSourceKey.Wrong]); ;
            
        }
    }
}
