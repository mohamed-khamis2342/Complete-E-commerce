using E_commerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace E_commerce.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.BillingAddress)
               .WithMany()
               .HasForeignKey(o => o.BillingAddressId)
               .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete
            // Order -> ShippingAddress 
            builder.HasOne(o => o.ShippingAddress)
                .WithMany()
                .HasForeignKey(o => o.ShippingAddressId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete
            // Order -> Cancellation 
            builder.HasOne(o => o.Cancellation)
                .WithOne(c => c.Order)
                .HasForeignKey<Cancellation>(c => c.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
