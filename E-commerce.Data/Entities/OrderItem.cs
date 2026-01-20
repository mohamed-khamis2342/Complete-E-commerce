using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Entities
{
    public class OrderItem
    {
            public Guid Id { get; set; }= Guid.NewGuid();

            public Guid OrderId { get; set; }

            [ForeignKey("OrderId")]
            public Order Order { get; set; }

            public Guid ProductId { get; set; }

            [ForeignKey("ProductId")]
            public Product Product { get; set; }

          
            public int Quantity { get; set; }

           
            public decimal UnitPrice { get; set; }

            public decimal Discount { get; set; }

        
            public decimal TotalPrice { get; set; }
        }
    }

