using Blog.BusinessLayer.Concrete;
using Blog.BusinessLayer.FluentValidation;
using Blog.DataLayer.EntityFramework;
using Blog.EntityLayer.Entities;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class AdminWriterController : Controller
    {
        protected WriterManager _writerManager = new WriterManager(new EfWriterDal());
        protected WriterValidator writervalidator = new WriterValidator();

        // GET: AdminWriter ---------------------------------------------------------------------
        public ActionResult IndexWriter(string keyword = "", int page = 1)
        {
            var writers = _writerManager.GetAllWriters(keyword).ToPagedList(page, 6);
            return View(writers);
        }

        // CREATE: AdminWriter ---------------------------------------------------------------------
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            ValidationResult result = writervalidator.Validate(writer);
            if (result.IsValid)
            {
                _writerManager.AddWriter(writer);
                return RedirectToAction("IndexWriter");
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

        // UPDATE: AdminWriter ---------------------------------------------------------------------
        [HttpGet]
        public ActionResult EditWriter(int id) 
        {
            var writer = _writerManager.GetWriterById(id);
            return View(writer);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult result = writervalidator.Validate(writer);
            if (result.IsValid)
            {
                _writerManager.UpdateWriter(writer);
                return RedirectToAction("IndexWriter");
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