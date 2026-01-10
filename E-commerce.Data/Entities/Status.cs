using System.ComponentModel.DataAnnotations;

namespace E_commerce.Entities
{
    public class Status
    {

  
        // Represents the status master
        [Required]
            public Guid Id { get; set; } = Guid.NewGuid();

            [Required]
            [StringLength(50)]
            public string Name { get; set; }
        
    }
}

