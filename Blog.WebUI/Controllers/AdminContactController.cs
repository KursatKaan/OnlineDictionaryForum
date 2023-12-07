using Blog.BusinessLayer.Concrete;
using Blog.BusinessLayer.FluentValidation;
using Blog.DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        protected ContactManager _contactManager = new ContactManager(new EfContactDal());
        protected ContactValidator contactvalidator = new ContactValidator();

        // GET: AdminContact --------------------------------------------------------------
        public ActionResult IndexContact()
        {
            var contacts = _contactManager.GetAllContacts();
            return View(contacts);
        }

        public ActionResult DetailsContact(int id) 
        {
            var detail = _contactManager.GetContactById(id);
            return View(detail);
        }
    }
}