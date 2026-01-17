using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.DTOs.Cart
{
   public class CartResponseDTO
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal TotalBasePrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalAmount { get; set; }
        public List<CartItemResponseDTO>? CartItems { get; set; }
    }
}
