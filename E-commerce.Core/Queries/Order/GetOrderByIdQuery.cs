using E_commerce.Core.DTOs.Order;
using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_commerce.Core.Queries.Order
{
    public class GetOrderByIdQuery:IRequest<ApiResponse<OrderResponseDTO>>
    {
        [Required(ErrorMessage ="Order Id is Required")]
        public Guid OrderId { get; set; }
    }
}
