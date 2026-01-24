using E_commerce.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Implementations
{
    public class PaginationService<T> :IPaginationService<T>
    {
     

        public async Task<IEnumerable<T>> PaginatedAsync(int pageNumber, int pageSize, IQueryable<T> query)
        {
            if (pageNumber <= 0)
                pageNumber = 1;

            if (pageSize <= 0)
                pageSize = 10;

            var totalCount =  query.Count();

            var items =  query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return items;
        }
    }

}
