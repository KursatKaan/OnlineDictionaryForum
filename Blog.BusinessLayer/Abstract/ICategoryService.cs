using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);
    }
}
