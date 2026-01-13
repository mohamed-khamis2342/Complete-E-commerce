using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_commerce.Core.Commends.Product
{
    public class DeleteProductCommend:IRequest<ApiResponse<string>>
    {
        [Required(ErrorMessage ="Id is required")]
        public Guid id { get; set; }
    }
}
