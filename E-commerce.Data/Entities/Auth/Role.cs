using Microsoft.AspNetCore.Identity;

namespace E_commerce.Auth
{
    public class Role:IdentityRole<Guid>
    {
        public string Discription { get; set; }
    }
}
