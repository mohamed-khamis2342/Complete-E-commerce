
using E_commerce.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Entities
{
    public class Customer
    {

        
            public Guid  Id { get; set; }


        public Guid ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Address> Addresses { get; set; }
            public ICollection<Order> Orders { get; set; }

            // Navigation property: A user can have many carts but only 1 active cart
            public ICollection<Cart> Carts { get; set; }
            public ICollection<Feedback> Feedbacks { get; set; }
        }
    }


