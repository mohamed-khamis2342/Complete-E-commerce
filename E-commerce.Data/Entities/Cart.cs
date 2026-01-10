using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Entities
{
    
        public class Cart
        {
            public Guid Id { get; set; } = Guid.NewGuid();
            public Guid CustomerId { get; set; }

            [ForeignKey("CustomerId")]
            public Customer Customer { get; set; }

            public bool IsCheckedOut { get; set; } = false;

            [Required]
            public DateTime CreatedAt { get; set; }

            [Required]
            public DateTime UpdatedAt { get; set; }

            public ICollection<CartItem> CartItems { get; set; }
        }
    }
