using E_commerce.Core.DTOs.Category;
using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Queries.Category
{
    public class GetAllCategoriesQuery: IRequest<ApiResponse<List<CategoryResponseDTO>>>
    {
    }
}
