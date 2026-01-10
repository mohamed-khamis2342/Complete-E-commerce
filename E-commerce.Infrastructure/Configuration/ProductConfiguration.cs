using E_commerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace E_commerce.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Seed Products
            builder.HasData(
                new Product
                {
                    Id = Guid.Parse("A0000000-1111-0000-0000-000000000001"),
                    Name = "Smartphone",
                    Description = "Latest model smartphone with advanced features.",
                    Price = 699.99m,
                    StockQuantity = 50,
                    ImageUrl = "https://example.com/images/smartphone.jpg",
                    DiscountPercentage = 10,
                    CategoryId = Guid.Parse("A0000000-1111-0000-0000-000000000002"),
                    IsAvailable = true
                },
                new Product
                {
                    Id = Guid.Parse("B0000000-2222-0000-0000-000000000002"),
                    Name = "Laptop",
                    Description = "High-performance laptop suitable for all your needs.",
                    Price = 999.99m,
                    StockQuantity = 30,
                    ImageUrl = "https://example.com/images/laptop.jpg",
                    DiscountPercentage = 15,
                    CategoryId = Guid.Parse("A0000000-1111-0000-0000-000000000002"),
                    IsAvailable = true
                },
                new Product
                {
                    Id = Guid.Parse("C0000000-0000-0000-0000-000000000001"),
                    Name = "Science Fiction Novel",
                    Description = "A thrilling science fiction novel set in the future.",
                    Price = 19.99m,
                    StockQuantity = 100,
                    ImageUrl = "https://example.com/images/scifi-novel.jpg",
                    DiscountPercentage = 5,
                    CategoryId = Guid.Parse("B0000000-2222-0000-0000-000000000001"),
                    IsAvailable = true
                }
            );
        
    }
    }
}
