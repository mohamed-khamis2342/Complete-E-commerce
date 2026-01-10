using E_commerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
          .HasOne(c => c.ApplicationUser)
       .WithOne()
       .HasForeignKey<Customer>(c => c.ApplicationUserId)
       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
