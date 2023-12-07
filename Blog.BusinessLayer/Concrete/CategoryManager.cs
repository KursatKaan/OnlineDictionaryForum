using Blog.BusinessLayer.Abstract;
using Blog.DataLayer.Abstract;
using Blog.DataLayer.Concrete;
using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        protected ICategoryDal _categoryDal;

        // Constructor
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        // CREATE: CategoryManager --------------------------
        public void AddCategory(Category category)
        {
            _categoryDal.Add(category);
        }

        // DELETE: CategoryManager --------------------------
        public void DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
        }

        // GET: CategoryManager --------------------------
        public IQueryable<Category> GetAllCategories()
        {
            return _categoryDal.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryDal.GetOne(x => x.Id == id);
        }

        // UPDATE: CategoryManager --------------------------
        public void UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
