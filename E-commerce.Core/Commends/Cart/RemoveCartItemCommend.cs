using E_commerce.Core.DTOs.Cart;
using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_commerce.Core.Commends.Cart
{
    public class RemoveCartItemCommend:IRequest<ApiResponse<CartResponseDTO>>
    {
        [Required(ErrorMessage = "CustomerId is required.")]
        public Guid CustomerId { get; set; }
        [Required(ErrorMessage = "CartItemId is required.")]
        public Guid CartItemId { get; set; }
    }
}
