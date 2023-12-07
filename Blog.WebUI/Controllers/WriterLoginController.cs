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
using System.Web.Security;

namespace Blog.WebUI.Controllers
{
    [AllowAnonymous]
    public class WriterLoginController : Controller
    {
        protected WriterManager _writerManager = new WriterManager(new EfWriterDal());


        // GET: WriterLogin ---------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Writer writer)
        {
            if (_writerManager.ValidateWriter(writer.Mail, writer.Password))
            {
                FormsAuthentication.SetAuthCookie(writer.Mail, false);
                Session["Mail"] = writer.Mail;
                return RedirectToAction("WriterProfile", "WriterPanelProfile");
            }
            else
            {
                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre");
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HeadingsSidebar", "Default");
        }
    }
}