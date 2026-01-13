using E_commerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Service.Abstracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category> CreateCategoryAsync(Category category);

        Task<Category> GetByIdAsync(Guid id);
        Task<string> UpdateCategoryAsync(Category category);
        Task<string> DeleteCategoryAsync(Category category);

    }
}
