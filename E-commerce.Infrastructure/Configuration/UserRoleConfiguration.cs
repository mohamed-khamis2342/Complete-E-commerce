using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "f27ee3db-8321-4247-bccb-3b06dbc8ff2d", // Admin User Id
                    RoleId = "11111111-1111-1111-1111-111111111111"  // Admin Role Id
                }
            );
        }
    }
}
