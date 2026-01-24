using E_commerce.Data.Entities;
using E_commerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.Configuration
{
    public class CancellationStatusConfiguration : IEntityTypeConfiguration<CancellationStatus>
    {
        public void Configure(EntityTypeBuilder<CancellationStatus> builder)
        {
            builder.HasData(

              new CancellationStatus { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Status = "Pending" },
               new CancellationStatus { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Status = "Approved" },
               new CancellationStatus { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Status = " Rejected " }


            );
        }
    }
}
