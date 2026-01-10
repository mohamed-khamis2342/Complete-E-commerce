using E_commerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace E_commerce.Configuration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData(
               //Order Statuses
               new Status { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Pending" },
                new Status { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Processing" },
                new Status { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Shipped" },
                new Status { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Delivered" },
                new Status { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Canceled" },

                // Refund Status
                new Status { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "Completed" },
                new Status { Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), Name = "Failed" },

                // Cancellation Statuses
                new Status { Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), Name = "Approved" },
                new Status { Id = Guid.Parse("99999999-9999-9999-9999-999999999999"), Name = "Rejected" },

                // Payment Status
                new Status { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), Name = "Refunded" }

             );
        }
    }
}
