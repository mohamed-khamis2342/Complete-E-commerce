using E_commerce.Core.DTOs.Category;
using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_commerce.Core.Commends.Category
{
    public class CreateCategoryCommend:IRequest<ApiResponse<CategoryResponseDTO>>
    {
        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Category Name must be between 3 and 100 characters.")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }
    }
}
