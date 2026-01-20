using E_commerce.Core.DTOs.Order;
using E_commerce.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_commerce.Core.Commends.Order
{
    public class CreatOrderCommend:IRequest<ApiResponse<OrderResponseDTO>>
    {
        [Required(ErrorMessage = "Customer ID is required.")]
        public Guid CustomerId { get; set; }
        [Required(ErrorMessage = "Billing Address ID is required.")]
        public Guid BillingAddressId { get; set; }
        [Required(ErrorMessage = "Shipping Address ID is required.")]
        public Guid ShippingAddressId { get; set; }
        [Required(ErrorMessage = "At least one order item is required.")]
        [MinLength(1, ErrorMessage = "At least one order item is required.")]
        public List<CreatOrderItemCommend> OrderItems { get; set; }
    }
}
