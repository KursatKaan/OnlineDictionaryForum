using Blog.BusinessLayer.Concrete;
using Blog.BusinessLayer.FluentValidation;
using Blog.DataLayer.Abstract;
using Blog.DataLayer.EntityFramework;
using Blog.EntityLayer.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class WriterPanelProfileController : Controller
    {
        protected WriterManager _writerManager = new WriterManager(new EfWriterDal());
        protected WriterValidator writervalidator = new WriterValidator();

        // GET: WriterPanelProfile ---------------------------------------------------------------------------
        [HttpGet]
        public ActionResult WriterProfile()
        {
            var mail = (string)Session["Mail"];
            var writerID = _writerManager.GetWriterIdByMail(mail);
            var writer = _writerManager.GetWriterById(writerID);
            return View(writer);
        }


        //UPDATE: WriterPanelProfile ---------------------------------------------------------------------------

        [HttpPost]
        public ActionResult WriterProfile(Writer writer, HttpPostedFileBase ImageFile)
        {
            ValidationResult result = writervalidator.Validate(writer);
            if (result.IsValid)
            {
                if (ImageFile != null)
                {
                    //writer.Image = ImageFile.FileName;
                    //var imagePath = Server.MapPath("~/Images/" + ImageFile.FileName);
                    var image = Path.GetFileName(ImageFile.FileName);
                    var imagePath = Path.Combine(Server.MapPath("~/Images/"), image);
                    ImageFile.SaveAs(imagePath);
                    writer.Image = "/Images/" + image;
                }
                _writerManager.UpdateWriter(writer);
                return RedirectToAction("WriterProfile");
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

        //[HttpPost]
        //public ActionResult WriterProfile(Writer writer)
        //{
        //    ValidationResult result = writervalidator.Validate(writer);
        //    if (result.IsValid)
        //    {
        //        _writerManager.UpdateWriter(writer);
        //        return RedirectToAction("WriterProfile");
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}
    }
}