using Blog.BusinessLayer.Concrete;
using Blog.BusinessLayer.FluentValidation;
using Blog.DataLayer.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class AdminContentController : Controller
    {
        protected ContentManager _contentManager = new ContentManager(new EfContentDal());
        protected HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());

        // GET: AdminContent ---------------------------------------------------------------------
        public ActionResult IndexContent(string keyword = "", int page = 1)
        {
            var contents = _contentManager.GetAllContents(keyword).ToPagedList(page, 10);
            return View(contents);
        }

        public ActionResult ContentByHeading(int id, int page = 1)
        {
            var heading = _headingManager.GetHeadingById(id);
            ViewBag.heading = heading.HeadingTitle;
            var content = _contentManager.GetContentsByHeading(id).ToPagedList(page, 10);
            return View(content);
        }
    }
}