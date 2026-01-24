using E_commerce.Core.DTOs.Category;
using E_commerce.Core.Queries.Category;
using E_commerce.Core.SharedDTO;
using E_commerce.DTOs;
using E_commerce.Service.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Category
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, ApiResponseFroPagination<List<CategoryResponseDTO>>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IPaginationService<Entities.Category> _paginationService;

        public GetAllCategoriesHandler(ICategoryService categoryService,
            IPaginationService<Entities.Category> paginationService)
        {
            this._categoryService = categoryService;
            this._paginationService = paginationService;
        }
        public async Task<ApiResponseFroPagination<List<CategoryResponseDTO>>> Handle(
       GetAllCategoriesQuery request,
       CancellationToken cancellationToken)
        {


            var categoriesFromDB = await _categoryService.GetAllCategoryAsync();

            if (categoriesFromDB == null || !categoriesFromDB.Any())
            {
                return new ApiResponseFroPagination<List<CategoryResponseDTO>>
                {
                    StatusCode = 200,
                    Success = true,
                    Data = new List<CategoryResponseDTO>()
                };
            }



            var PaginatedList = await _paginationService
                .PaginatedAsync(request.PageNumber, request.Pagesize,categoriesFromDB.AsQueryable() );


            var categories =  PaginatedList.Select(category => new CategoryResponseDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive,
               
            }).ToList();


            return new ApiResponseFroPagination<List<CategoryResponseDTO>>
            {
               
                StatusCode = 200,
                Success = true,
                PageNumber = request.PageNumber,
                PageSize = request.Pagesize,
                Data = categories
            };
        }

    }
}
