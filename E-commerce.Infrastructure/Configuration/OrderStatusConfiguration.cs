using E_commerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.Configuration
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatuses>
    {
   
        public void Configure(EntityTypeBuilder<OrderStatuses> builder)
        {
            builder.HasData(
                new OrderStatuses
                {
                    Id = Guid.Parse("A1111111-1111-1111-1111-111111111111"),
                    Name = "Pending"
                },
                new OrderStatuses
                {
                    Id = Guid.Parse("B2222222-2222-2222-2222-222222222222"),
                    Name = "Processing"
                },
                new OrderStatuses
                {
                    Id = Guid.Parse("C3333333-3333-3333-3333-333333333333"),
                    Name = "Shipped"
                },
                new OrderStatuses
                {
                    Id = Guid.Parse("D4444444-4444-4444-4444-444444444444"),
                    Name = "Delivered"
                },
                new OrderStatuses
                {
                    Id = Guid.Parse("E5555555-5555-5555-5555-555555555555"),
                    Name = "Canceled"
                }
            );
        }

    }
}

