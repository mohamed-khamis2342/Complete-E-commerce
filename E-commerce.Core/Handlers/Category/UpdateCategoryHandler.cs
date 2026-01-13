using E_commerce.Core.Commends.Category;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Category
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommend, ApiResponse<string>>
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryHandler(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public async Task<ApiResponse<string>> Handle(UpdateCategoryCommend request, CancellationToken cancellationToken)
        {
            var UpdatedCat = new Entities.Category
            {
                Id =  request.Id,
                Name = request.Name,
                Description = request.Description

            };

            var result = await _categoryService.UpdateCategoryAsync(UpdatedCat);
            if (!string.IsNullOrEmpty(result))
                return new ApiResponse<string>
                {
                    StatusCode = 200,
                    Success = true,

                    Data = "updated Successfully"
                };

            return new ApiResponse<string>(400,"Something went wrong"); ;
        }
    }
}
