using E_commerce.Entities;
using E_commerce.Infrastructure.Abstractes;
using E_commerce.Infrastructure.AppContext;
using E_commerce.Infrastructure.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.Repository
{
    public class CategoryRepository : GenericRepositoryAsync<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
