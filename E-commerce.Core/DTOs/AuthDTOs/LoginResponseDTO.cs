using System.Text.Json.Serialization;

namespace E_commerce.DTOs.AuthDTOs
{
    public class LoginResponseDTO
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string Token { get; set; }   
        public string Message { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }  
       public List<string> Roles { get; set; }      

        //Refresh Tokens
        //i will have it in memory to use it latter 
        [JsonIgnore]

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpires { get; set; }

    }
}
