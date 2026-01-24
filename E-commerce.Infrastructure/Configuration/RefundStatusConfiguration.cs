using E_commerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.Configuration
{
    public class RefundStatusConfiguration : IEntityTypeConfiguration<RefundStatus>
    {
        public void Configure(EntityTypeBuilder<RefundStatus> builder)
        {
            builder.HasData(

             new RefundStatus { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Status = "Pending" },
              new RefundStatus { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Status = "Completed" },
              new RefundStatus { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Status = "Failed" }


           );
        }
    }
}
