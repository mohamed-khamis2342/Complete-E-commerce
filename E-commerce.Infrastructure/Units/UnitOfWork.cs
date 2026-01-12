using E_commerce.Entities;
using E_commerce.Infrastructure.AppContext;
using E_commerce.Infrastructure.InfrastructureBase;
using E_commerce.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Units
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private GenericRepositoryAsync<Address> _addressRepositoryAsync;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public GenericRepositoryAsync<Address> AddressReporsitory
        {
            get
            {
                if (_addressRepositoryAsync == null)
                {
                    _addressRepositoryAsync = new GenericRepositoryAsync<Address>(_context);
                }
                return _addressRepositoryAsync;
            }
        }
































        public async Task SaveChanges() { 

            await _context.SaveChangesAsync();  
        }
    }
}
