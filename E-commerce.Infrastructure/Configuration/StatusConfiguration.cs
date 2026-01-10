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
                 new Status { Id = 1, Name = "Pending" }, //Can be used to with Order, Paymeny, Cancellation, and Refund
                 new Status { Id = 2, Name = "Processing" },
                 new Status { Id = 3, Name = "Shipped" },
                 new Status { Id = 4, Name = "Delivered" },
                 new Status { Id = 5, Name = "Canceled" },
                 //Refund Status
                 new Status { Id = 6, Name = "Completed" },
                 new Status { Id = 7, Name = "Failed" },
                 //Cancellation Statuses
                 new Status { Id = 8, Name = "Approved" },
                 new Status { Id = 9, Name = "Rejected" },
                 //Payment Status
                 new Status { Id = 10, Name = "Refunded" }
             );
        }
    }
}
