using Blog.BusinessLayer.Concrete;
using Blog.BusinessLayer.FluentValidation;
using Blog.DataLayer.EntityFramework;
using Blog.EntityLayer.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class AdminCategoryController : Controller
    {
        protected CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

        // GET: AdminCategory ------------------------------------------------------------------------
        public ActionResult IndexCategory()
        {
            var categories = _categoryManager.GetAllCategories();
            return View(categories);
        }

        // CREATE: AdminCategory ---------------------------------------------------------------------
        [HttpGet]
        public ActionResult AddCategory() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category) 
        {
            CategoryValidator categoryvalidator = new CategoryValidator();
            ValidationResult result = categoryvalidator.Validate(category);
            if (result.IsValid)
            {
                _categoryManager.AddCategory(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        // DELETE: AdminCategory ---------------------------------------------------------------------
        public ActionResult DeleteCategory(int id)
        {
            var category = _categoryManager.GetCategoryById(id);
            _categoryManager.DeleteCategory(category);
            return RedirectToAction("Index");
        }

        // UPDATE: AdminCategory ---------------------------------------------------------------------
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = _categoryManager.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            CategoryValidator categoryvalidator = new CategoryValidator();
            ValidationResult result = categoryvalidator.Validate(category);
            if (result.IsValid)
            {
                _categoryManager.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}