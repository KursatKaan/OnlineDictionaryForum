using Blog.BusinessLayer.Concrete;
using Blog.DataLayer.Context;
using Blog.DataLayer.EntityFramework;
using Blog.EntityLayer.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class WriterPanelContentController : Controller
    {
        protected ContentManager _contentManager = new ContentManager(new EfContentDal());
        protected WriterManager _writerManager = new WriterManager(new EfWriterDal());
        protected HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());

        // GET: WriterPanelContent --------------------------------------------------------------
        public ActionResult WriterContent(string keyword = "", int page = 1)
        {
            var mail = (string)Session["Mail"];
            var writerID = _writerManager.GetWriterIdByMail(mail);
            var contents = _contentManager.GetContentsByWriter(writerID, keyword).ToPagedList(page, 10);
            return View(contents);
        }

        public ActionResult ContentByHeading(int id, int page = 1)
        {
            var heading = _headingManager.GetActiveHeadingById(id);
            ViewBag.heading = heading.HeadingTitle;
            var content = _contentManager.GetContentsByHeading(id).ToPagedList(page, 10);
            return View(content);
        }

        // CREATE: WriterPanelContent --------------------------------------------------------------

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.id = id;
            var heading = _headingManager.GetActiveHeadingById(id);
            ViewBag.HeadingTitle = heading.HeadingTitle;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            var mail = (string)Session["Mail"];
            content.WriterId = _writerManager.GetWriterIdByMail(mail);
            content.ContentStatus = true;
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _contentManager.AddContent(content);
            return RedirectToAction("WriterContent");
        }
    }
}