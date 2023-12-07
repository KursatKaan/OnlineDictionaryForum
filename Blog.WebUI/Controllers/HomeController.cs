using Blog.BusinessLayer.Concrete;
using Blog.DataLayer.EntityFramework;
using Blog.EntityLayer.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer.Symbols;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        protected HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        protected ContentManager _contentManager = new ContentManager(new EfContentDal());

        // GET: Default ------------------------------------------------------


        public ActionResult Home()
        {

            var headinglist = _headingManager.GetAllHeadingsForSidebar();

            foreach (var heading in headinglist)
            {
                ViewData["ContentsCount_" + heading.Id] = _contentManager.GetContentsByHeading(heading.Id).Count();
            }
            return View(headinglist);
        }


        public PartialViewResult Index(string keyword = "")
        {
            var allHeadings = _headingManager.GetAllHeadingsForWriter(keyword);

            foreach (var heading in allHeadings)
            {
                var latestContent = _contentManager.GetContentsByHeading(heading.Id).FirstOrDefault();

                ViewData["LatestContent_" + heading.Id] = latestContent?.ContentText;
                ViewData["WriterInfo_" + heading.Id] = latestContent != null ? latestContent.Writer.Name + " " + latestContent.Writer.Surname : null;
                ViewData["ContentDate_" + heading.Id] = latestContent?.ContentDate.ToString("dd.MM.yyyy HH:mm");

            }

            return PartialView(allHeadings);

        }

        public PartialViewResult IndexByHeading(int id)
        {

            var heading = _headingManager.GetActiveHeadingById(id);
            ViewData["heading"] = heading.HeadingTitle;
            var headingcontents = _contentManager.GetContentsByHeading(id);

            return PartialView(headingcontents);

        }

    }
}