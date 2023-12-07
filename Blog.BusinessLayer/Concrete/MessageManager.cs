using Blog.BusinessLayer.Abstract;
using Blog.DataLayer.Abstract;
using Blog.DataLayer.EntityFramework;
using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        protected IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void AddMessage(Message message)
        {
            _messageDal.Add(message);
        }

        public void DeleteMessage(Message message)
        {
            message.MessageStatus = !message.MessageStatus; //Tamamen silme işlemi yerine Mesaj durumu değişir.
            _messageDal.Update(message);
        }

        public Message GetMessageById(int id)
        {
            return _messageDal.GetOne(x => x.Id == id);
        }

        public IQueryable<Message> GetTrashMessage(string mail)
        {
            return _messageDal.GetAll(x => x.MessageStatus == false && x.IsDraft == false && (x.SenderMail == mail || x.ReceiverMail == mail)).OrderByDescending(x => x.MessageDate);
        }

        public IQueryable<Message> GetInboxMessage(string mail)
        {
            return _messageDal.GetAll(x => x.MessageStatus == true && x.IsDraft == false && x.ReceiverMail == mail).OrderByDescending(x => x.MessageDate);
        }

        public IQueryable<Message> GetOutboxMessage(string mail)
        {
            return _messageDal.GetAll(x => x.MessageStatus == true && x.IsDraft == false && x.SenderMail == mail).OrderByDescending(x => x.MessageDate);
        }

        public void UpdateMessage(Message message)
        {
            message.IsDraft = !message.IsDraft; //Tamamen silme işlemi yerine Mesaj durumu değişir.
            _messageDal.Update(message);
        }
    }
}
