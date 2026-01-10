
using E_commerce.Service;

namespace E_commerce.DTOs.AuthDTOs
{
    public class RegisterResponseDTO
    {
        public  Guid Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
