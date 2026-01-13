using E_commerce.Entities;
using E_commerce.Infrastructure.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.Abstractes
{
    public interface ICategoryRepository:IGenericRepositoryAsync<Category>
    {
    }
}
