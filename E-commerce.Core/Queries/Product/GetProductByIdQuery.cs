using E_commerce.Core.DTOs.Product;
using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_commerce.Core.Queries.Product
{
    public class GetProductByIdQuery:IRequest<ApiResponse<ProductResponseDTO>>
    {
        [Required(ErrorMessage ="Id is Required")]
        public Guid Id {  get; set; }
    }
}
