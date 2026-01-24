using E_commerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.Configuration
{
    public class RefundMethodConfiguration : IEntityTypeConfiguration<RefundMethod>
    {
        public void Configure(EntityTypeBuilder<RefundMethod> builder)
        {
            builder.HasData(
             new RefundMethod
             {
                 Id = Guid.Parse("A1111111-1111-1111-1111-111111111111"),
                 Method = "Original"
             },
             new RefundMethod
             {
                 Id = Guid.Parse("B2222222-2222-2222-2222-222222222222"),
                 Method = "PayPal"
             },
             new RefundMethod
             {
                 Id = Guid.Parse("C3333333-3333-3333-3333-333333333333"),
                 Method = "Stripe"
             },
             new RefundMethod
             {
                 Id = Guid.Parse("D4444444-4444-4444-4444-444444444444"),
                 Method = "BankTransfer"
             },
             new RefundMethod
             {
                 Id = Guid.Parse("E5555555-5555-5555-5555-555555555555"),
                 Method = "Manual"
             }
         );
        }
    }
}
