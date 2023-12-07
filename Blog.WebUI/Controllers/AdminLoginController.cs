using Blog.BusinessLayer.Abstract;
using Blog.BusinessLayer.Concrete;
using Blog.DataLayer.Context;
using Blog.DataLayer.EntityFramework;
using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.WebUI.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        protected AdminManager _adminManager = new AdminManager(new EfAdminDal());

        // GET: AdminLogin ---------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var adminInfo = _adminManager.ValidateAdmin(admin.AdminUserName, admin.AdminPassword);
            if (adminInfo)
            {
                FormsAuthentication.SetAuthCookie(admin.AdminUserName, false);
                Session["AdminUserName"] = admin.AdminUserName;
                return RedirectToAction("IndexCategory", "AdminCategory");
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