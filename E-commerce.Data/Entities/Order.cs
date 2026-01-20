
using E_commerce.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Entities
{
    public class Order
    {
            public Guid Id { get; set; } = Guid.NewGuid();

            [Required]
            [StringLength(30, ErrorMessage = "Order Number cannot exceed 30 characters.")]
            public string OrderNumber { get; set; }

            [Required]
            public DateTime OrderDate { get; set; }

            // Foreign key to Customer
            [Required(ErrorMessage = "Customer ID is required.")]
            public Guid CustomerId { get; set; }

            [ForeignKey("CustomerId")]
            public Customer Customer { get; set; }

            // Foreign keys to Addresses
            [Required(ErrorMessage = "Billing Address ID is required.")]
            public Guid BillingAddressId { get; set; }

            [ForeignKey("BillingAddressId")]
            public Address BillingAddress { get; set; }

            [Required(ErrorMessage = "Shipping Address ID is required.")]
            public Guid ShippingAddressId { get; set; }

            [ForeignKey("ShippingAddressId")]
            public Address ShippingAddress { get; set; }

          
            public decimal TotalBaseAmount { get; set; }

           
            public decimal TotalDiscountAmount { get; set; }

         
            public decimal ShippingCost { get; set; }

       
            public decimal TotalAmount { get; set; }


        public Guid StatusId { get; set; }   // FK
        [ForeignKey("StatusId")]
        public OrderStatuses Status { get; set; }

        [Required]
            public ICollection<OrderItem> OrderItems { get; set; }
            public Payment Payment { get; set; } //Linked with Associated Payment
            public Cancellation Cancellation { get; set; } //Linked with Associated Cancellation
        }
    }

