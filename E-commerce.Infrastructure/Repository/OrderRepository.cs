using E_commerce.Entities;
using E_commerce.Infrastructure.Abstractes;
using E_commerce.Infrastructure.AppContext;
using E_commerce.Infrastructure.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.Repository
{
    public class OrderRepository : GenericRepositoryAsync<Order>,IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
