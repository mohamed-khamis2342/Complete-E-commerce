
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.DTOs.Order
{
    public class OrderResponseDTO
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BillingAddressId { get; set; }
        public Guid ShippingAddressId { get; set; }
        public decimal TotalBaseAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalAmount { get; set; }
     
        public List<OrderItemResponseDTO> OrderItems { get; set; }
    }
}
