using Blog.BusinessLayer.Concrete;
using Blog.BusinessLayer.FluentValidation;
using Blog.DataLayer.Context;
using Blog.DataLayer.EntityFramework;
using Blog.EntityLayer.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity.Infrastructure;

namespace Blog.WebUI.Controllers
{
    public class WriterPanelHeadingController : Controller
    {
        protected HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        protected WriterManager _writerManager = new WriterManager(new EfWriterDal());
        protected HeadingValidator headingValidator = new HeadingValidator();

        // GET: WriterPanelHeading -----------------------------------------------------------------------

        public ActionResult WriterHeading(string keyword = "",int page = 1)
        {
            var mail = (string)Session["Mail"];
            var writerID = _writerManager.GetWriterIdByMail(mail);
            var headings = _headingManager.GetHeadingsByWriter(writerID,keyword).ToPagedList(page, 10);

            return View(headings);
        }

        public ActionResult AllHeadings( string keyword = "", int page = 1)
        {
            var allheadings = _headingManager.GetAllHeadingsForWriter(keyword).ToPagedList(page, 10);
            return View(allheadings);
        }


        //CREATE: WriterPanelHeading ---------------------------------------------------------------------
        [HttpGet]
        public ActionResult NewHeading()
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
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            ValidationResult result = headingValidator.Validate(heading);
            if (result.IsValid)
            {
                var mail = (string)Session["Mail"];
                var writerID = _writerManager.GetWriterIdByMail(mail);
                heading.WriterId = writerID;
                heading.HeadingStatus = true;
                heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _headingManager.AddHeading(heading);
                return RedirectToAction("WriterHeading");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(heading);
        }

        // DELETE: WriterPanelHeading ---------------------------------------------------------------------
        public ActionResult DeleteHeading(int id)
        {
            var heading = _headingManager.GetActiveHeadingById(id);
            _headingManager.DeleteHeading(heading);
            return RedirectToAction("WriterHeading");
        }

    }
}