using E_commerce.Data.Entities;
using E_commerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.Configuration
{
    public class PaymentStatusConfiguration : IEntityTypeConfiguration<PaymentStatus>
    {
        public void Configure(EntityTypeBuilder<PaymentStatus> builder)
        {
            builder.HasData(
        
               new PaymentStatus { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Status = "Pending" },
                new PaymentStatus { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Status = "Completed" },
                new PaymentStatus { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Status = "Failed" },
                new PaymentStatus { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Status = "Refunded" }


             );
        }
    }
}
