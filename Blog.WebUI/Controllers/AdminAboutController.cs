using Blog.BusinessLayer.Concrete;
using Blog.BusinessLayer.FluentValidation;
using Blog.DataLayer.Abstract;
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
    public class AdminAboutController : Controller
    {
        protected AboutManager _aboutManager = new AboutManager(new EfAboutDal());
        protected AboutValidator aboutValidator = new AboutValidator();

        // GET: AdminAbout --------------------------------------------------------------------------------
        public ActionResult IndexAbout(int id = 1)
        {
            var about = _aboutManager.GetAboutById(id);
            return View(about);
        }


        // UPDATE: AdminAbout --------------------------------------------------------------------------------
        [HttpGet]
        public PartialViewResult EditAbout(int id)
        {
            About about = _aboutManager.GetAboutById(id);
            return PartialView(about);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditAbout(About about)
        {
            ValidationResult result = aboutValidator.Validate(about);
            if (result.IsValid)
            {
                _aboutManager.UpdateAbout(about);
                return RedirectToAction("IndexAbout");
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