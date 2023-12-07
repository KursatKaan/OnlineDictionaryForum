using Blog.BusinessLayer.Concrete;
using Blog.BusinessLayer.FluentValidation;
using Blog.DataLayer.EntityFramework;
using Blog.EntityLayer.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;

namespace Blog.WebUI.Controllers
{
    public class AdminMessageController : Controller
    {
        protected MessageManager _messageManager = new MessageManager(new EfMessageDal());
        protected MessageValidator messagevalidator = new MessageValidator();

        // GET: AdminMessage -----------------------------------------------------------------------
        public ActionResult InboxMessage()
        {
            var mail = (string)Session["Mail"];
            var inboxmessages = _messageManager.GetInboxMessage(mail);
            return View(inboxmessages);
        }

        public ActionResult InboxDetailsMessage(int id)
        {
            var detail = _messageManager.GetMessageById(id);
            return View(detail);
        }
        public ActionResult OutboxMessage()
        {
            var mail = (string)Session["Mail"];
            var outboxmessages = _messageManager.GetOutboxMessage(mail);
            return View(outboxmessages);
        }

        public ActionResult OutboxDetailsMessage(int id)
        {
            var detail = _messageManager.GetMessageById(id);
            return View(detail);
        }

        public ActionResult TrashMessage()
        {
            var mail = (string)Session["Mail"];
            var deletedmessages = _messageManager.GetTrashMessage(mail);
            return View(deletedmessages);
        }

        public ActionResult TrashDetailsMessage(int id)
        {
            var detail = _messageManager.GetMessageById(id);
            return View(detail);
        }



        // CREATE: AdminMessage -----------------------------------------------------------------------

        [HttpGet]
        public ActionResult ComposeMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ComposeMessage(Message message)
        {
            message.SenderMail = "admin@gmail.com";
            ValidationResult result = messagevalidator.Validate(message);

            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _messageManager.AddMessage(message);
                return RedirectToAction("OutboxMessage");
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

        // DELETE: AdminMessage -----------------------------------------------------------------------
        public ActionResult DeleteMessage(int id, string boxType)
        {
            var message = _messageManager.GetMessageById(id);
            _messageManager.DeleteMessage(message);

            if (boxType == "inbox")
            {
                return RedirectToAction("InboxMessage");
            }
            else if (boxType == "outbox")
            {
                return RedirectToAction("OutboxMessage");
            }

            return RedirectToAction("TrashMessage");

        }
    }
}