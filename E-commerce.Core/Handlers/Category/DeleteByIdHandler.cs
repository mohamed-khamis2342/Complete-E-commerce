using E_commerce.Core.Commends.Category;
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
    public class DeleteByIdHandler : IRequestHandler<DeleteCtegoryByIdCommend, ApiResponse<string>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<SharedSource> _stringLocalizer;

        public DeleteByIdHandler(ICategoryService categoryService, IStringLocalizer<SharedSource> stringLocalizer)
        {
            this._categoryService = categoryService;
            this._stringLocalizer = stringLocalizer;
        }
        public async Task<ApiResponse<string>> Handle(DeleteCtegoryByIdCommend request, CancellationToken cancellationToken)
        {
            var categoryFromDb = await _categoryService.GetByIdAsync(request.Id);   

            if (categoryFromDb == null) 
                return new ApiResponse<string>(400,"Not found");



            var result = await _categoryService.DeleteCategoryAsync(categoryFromDb);

            if (string.IsNullOrEmpty(result))
                return new ApiResponse<string>()
                {
                    StatusCode = 400,
                    Data = _stringLocalizer[SharedSourceKey.Wrong]

                };





            return new ApiResponse<string>()
            {
                StatusCode = 200,
                Success = true,
                Data = $"Category with Id {request.Id} {_stringLocalizer[SharedSourceKey.Deleted]}"
            };
        
        }
    }
}
