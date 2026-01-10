using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse( "D5ACB06C-075D-458E-3AE2-08DE50A20B3D"), // Admin User Id
                    RoleId = Guid.Parse("11111111-1111-1111-1111-111111111111")  // Admin Role Id
                }
            );
        }
    }
}
