using E_commerce.Entities;
using E_commerce.Infrastructure.Abstractes;
using E_commerce.Infrastructure.Repository;
using E_commerce.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace E_commerce.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
             
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {

         var CategoryAdded  =  await _categoryRepository.AddAsync(category);

            return CategoryAdded;

        }

        public async Task<string> DeleteCategoryAsync(Category category)
        {
            var result = _categoryRepository.DeleteAsync(category);

            if (!result.IsCompleted)
                return "Delete Failed";
            return string.Empty;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var Category = await _categoryRepository.GetByIdAsync(id);

            return Category;
        }

        public async Task<string> UpdateCategoryAsync(Category category)
        {
            var result = _categoryRepository.UpdateAsync(category);

            if (!result.IsCompleted)
                return "Update failed";

            return string.Empty;
        }
    }
}
