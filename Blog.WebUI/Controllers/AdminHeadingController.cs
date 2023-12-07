using Blog.BusinessLayer.Concrete;
using Blog.BusinessLayer.FluentValidation;
using Blog.DataLayer.EntityFramework;
using Blog.EntityLayer.Entities;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer.Symbols;
using System.Web.UI;

namespace Blog.WebUI.Controllers
{
    public class AdminHeadingController : Controller
    {
        protected HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        protected CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        protected HeadingValidator headingValidator = new HeadingValidator();


        // GET: AdminHeading ---------------------------------------------------------------------
        public ActionResult IndexHeading(string keyword = "", int page = 1)
        {
            var headings = _headingManager.GetAllHeadings(keyword).ToPagedList(page, 10);
            return View(headings);
        }

        public ActionResult HeadingByCategory(int id, int page = 1)
        {
            var category = _categoryManager.GetCategoryById(id);
            ViewBag.category = category.CategoryName;
            var heading = _headingManager.GetHeadingsByCategory(id).ToPagedList(page, 10);
            return View(heading);
        }
        

        //CREATE: AdminHeading ---------------------------------------------------------------------
        [HttpGet]
        public ActionResult AddHeading(string keyword = "")
        {
            WriterManager _writerManager = new WriterManager(new EfWriterDal());
            //DropDownList Categories
            IQueryable<SelectListItem> categories = (from x in _categoryManager.GetAllCategories()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.CategoryName,
                                                         Value = x.Id.ToString()
                                                     }).AsQueryable();
            //DropDownList Writers
            IQueryable<SelectListItem> writers = (from x in _writerManager.GetAllWriters(keyword)
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name + " " + x.Surname,
                                                      Value = x.Id.ToString()
                                                  }).AsQueryable();
            ViewBag.categories = categories;
            ViewBag.writers = writers;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            ValidationResult result = headingValidator.Validate(heading);
            if (result.IsValid)
            {
                heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _headingManager.AddHeading(heading);
                return RedirectToAction("IndexHeading");
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

        // DELETE: AdminHeading ---------------------------------------------------------------------
        public ActionResult DeleteHeading(int id, string callingAction)
        {
            var heading = _headingManager.GetHeadingById(id);
            _headingManager.DeleteHeading(heading);
            switch (callingAction)
            {
                case "IndexHeading":
                    return RedirectToAction("IndexHeading");

                case "HeadingByCategory":
                    return RedirectToAction("HeadingByCategory", new { id = heading.CategoryId });

                default:
                    return RedirectToAction("IndexHeading");
            }
        }

        // UPDATE: AdminHeading ---------------------------------------------------------------------

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
            //DropDownList Categories
            IQueryable<SelectListItem> categories = (from x in _categoryManager.GetAllCategories()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.CategoryName,
                                                         Value = x.Id.ToString()
                                                     }).AsQueryable();
            ViewBag.categories = categories;

            var heading = _headingManager.GetHeadingById(id);
            return View(heading);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            ValidationResult result = headingValidator.Validate(heading);
            if (result.IsValid)
            {
                _headingManager.UpdateHeading(heading);
                return RedirectToAction("IndexHeading");
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