using E_commerce.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = Guid.Parse( "11111111-1111-1111-1111-111111111111"),
                    Name = "Admin",
                    ConcurrencyStamp=null,
                    NormalizedName = "ADMIN",
                    Discription = "System Administrator"
                },
                new Role
                {
                    Id =Guid.Parse( "22222222-2222-2222-2222-222222222222"),
                    Name = "Customer",
                    ConcurrencyStamp = null,
                    NormalizedName = "CUSTOMER",
                    Discription = "Regular customer"
                }
             
           
            );
        }
    }

}
//, "fe8ce4c2-7a81-4962-8381-b1bb524a9d0f", "System Administrator", "Admin", "ADMIN" },
//                    {
//    "22222222-2222-2222-2222-222222222222", "4060e347-580f-48fe-8c89-eb0dcd8cf6e8",
