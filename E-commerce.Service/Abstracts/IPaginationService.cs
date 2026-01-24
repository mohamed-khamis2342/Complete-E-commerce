using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Abstracts
{
    public interface IPaginationService<T>
    {
        Task<IEnumerable<T>> PaginatedAsync(int pageNumber, int pageSize, IQueryable<T> query);
    }
}
