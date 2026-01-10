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
           new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and accessories", IsActive = true },
           new Category { Id = 2, Name = "Books", Description = "Books and magazines", IsActive = true }
       );

        }
    }
}
