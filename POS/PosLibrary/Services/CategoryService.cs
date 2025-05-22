using PosLibrary.Model;
using PosLibrary.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _repo.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _repo.GetById(id);
        }

        public void AddCategory(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }
            var category = new Category { Name = categoryName.Trim() };
            _repo.Add(category);
        }

        public void UpdateCategory(int id, string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }

            var category = new Category { Id = id, Name = categoryName.Trim() } ;

            _repo.Update(category);
        }

        public void DeleteCategory(int id)
        {
            _repo.Delete(id);
        }
    }
}
