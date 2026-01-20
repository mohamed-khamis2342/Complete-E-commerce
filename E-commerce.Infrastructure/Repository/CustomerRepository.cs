using E_commerce.Entities;
using E_commerce.Infrastructure.Abstractes;
using E_commerce.Infrastructure.AppContext;
using E_commerce.Infrastructure.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.Repository
{
    public class CustomerRepository : GenericRepositoryAsync<Customer>,ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
