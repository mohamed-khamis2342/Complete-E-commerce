using E_commerce.Core.DTOs.Cart;
using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_commerce.Core.Queries.ShoppingCart
{
    public class GetCartByCustomerIdQuery:IRequest<ApiResponse<CartResponseDTO>>
    {
        [Required(ErrorMessage ="Customer Id is Required")]
        public Guid CustomerId { get; set; }
    }
}
