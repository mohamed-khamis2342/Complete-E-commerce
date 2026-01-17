using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Infrastructure.InfrastructureBase
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
      
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);

        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task<T> AddAsync(T entity);
     
        Task UpdateAsync(T entity);
      
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
