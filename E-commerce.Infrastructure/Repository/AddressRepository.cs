using E_commerce.Entities;
using E_commerce.Infrastructure.Abstractes;
using E_commerce.Infrastructure.AppContext;
using E_commerce.Infrastructure.InfrastructureBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.Repository
{
    public class AddressRepository : GenericRepositoryAsync<Address>, IAddressRepository
    {
        private readonly DbSet<Address> _addresses;
        public AddressRepository(ApplicationDbContext dbContext):base(dbContext) { 
           
        
        }


    }
}
