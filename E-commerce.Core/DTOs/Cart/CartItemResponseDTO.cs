using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.DTOs.Cart
{
    public class CartItemResponseDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
