
using Microsoft.AspNetCore.Identity;


namespace E_commerce.Auth
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }  = new List<RefreshToken>();   

    }
}
