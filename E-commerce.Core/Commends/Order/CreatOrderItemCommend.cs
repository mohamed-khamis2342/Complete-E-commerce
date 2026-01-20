using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_commerce.Core.Commends.Order
{
    public class CreatOrderItemCommend
    {
        [Required(ErrorMessage = "Product ID is required.")]
        public Guid ProductId { get; set; }
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        public int Quantity { get; set; }
    }
}
