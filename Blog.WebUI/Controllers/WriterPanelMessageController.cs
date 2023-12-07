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

namespace Blog.WebUI.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        protected MessageManager _messageManager = new MessageManager(new EfMessageDal());
        protected MessageValidator messagevalidator = new MessageValidator();

        // GET: WriterPanelMessage ---------------------------------------------------------------------------
        public ActionResult WriterInboxMessage()
        {
            var mail = (string)Session["Mail"];
            var inboxmessages = _messageManager.GetInboxMessage(mail);
            return View(inboxmessages);
        }

        public ActionResult WriterOutboxMessage()
        {
            var mail = (string)Session["Mail"];
            var outboxmessages = _messageManager.GetOutboxMessage(mail);
            return View(outboxmessages);
        }

        public ActionResult WriterTrashMessage()
        {
            var mail = (string)Session["Mail"];
            var deletedmessages = _messageManager.GetTrashMessage(mail);
            return View(deletedmessages);
        }

        public ActionResult WriterInboxDetailsMessage(int id)
        {
            var detail = _messageManager.GetMessageById(id);
            return View(detail);
        }

        public ActionResult WriterOutboxDetailsMessage(int id)
        {
            var detail = _messageManager.GetMessageById(id);
            return View(detail);
        }

        public ActionResult WriterTrashDetailsMessage(int id)
        {
            var detail = _messageManager.GetMessageById(id);
            return View(detail);
        }

        // CREATE: WriterPanelMessage -----------------------------------------------------------------------

        [HttpGet]
        public ActionResult ComposeMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ComposeMessage(Message message)
        {
            var mail = (string)Session["Mail"];
            ValidationResult result = messagevalidator.Validate(message);

            if (result.IsValid)
            {
                message.SenderMail = mail;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _messageManager.AddMessage(message);
                return RedirectToAction("WriterOutboxMessage");
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

        // DELETE: WriterPanelMessage -----------------------------------------------------------------------
        public ActionResult DeleteMessage(int id, string boxType)
        {
            var message = _messageManager.GetMessageById(id);
            _messageManager.DeleteMessage(message);

            if (boxType == "inbox")
            {
                return RedirectToAction("WriterInboxMessage");
            }
            else if (boxType == "outbox")
            {
                return RedirectToAction("WriterOutboxMessage");
            }

            return RedirectToAction("WriterTrashMessage");

        }
    }
}