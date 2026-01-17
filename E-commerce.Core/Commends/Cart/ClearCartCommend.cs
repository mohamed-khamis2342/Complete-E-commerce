using E_commerce.Core.DTOs.Cart;
using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_commerce.Core.Commends.Cart
{
    public class ClearCartCommend:IRequest<ApiResponse<CartResponseDTO>>
    {
        [Required(ErrorMessage = "CustomerId is required.")]
        public Guid CustomerId { get; set; }
    }
}
