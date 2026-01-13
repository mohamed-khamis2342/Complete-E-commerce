using E_commerce.Core.DTOs.Category;
using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_commerce.Core.Queries.Category
{
    public class GetCategoryByIdQuery:IRequest<ApiResponse<CategoryResponseDTO>>
    {
        [Required(ErrorMessage = "category Id is Required")]
        public Guid Id { get; set; }
    }
}
