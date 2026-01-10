using E_commerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace E_commerce.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
           new Category { Id = Guid.Parse("A0000000-1111-0000-0000-000000000002"), Name = "Electronics", Description = "Electronic devices and accessories", IsActive = true },
           new Category { Id = Guid.Parse("B0000000-2222-0000-0000-000000000001"), Name = "Books", Description = "Books and magazines", IsActive = true }
       );

        }
    }
}
