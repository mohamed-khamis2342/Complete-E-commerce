using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_commerce.Core.Commends.Category
{
    public class DeleteCtegoryByIdCommend:IRequest<ApiResponse<string>>
    {
        [Required(ErrorMessage ="Category id is Required")]
        public Guid Id { get; set; }
    }
}
