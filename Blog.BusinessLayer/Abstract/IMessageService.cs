using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Abstract
{
    public interface IMessageService
    {
        IQueryable<Message> GetInboxMessage(string mail);
        IQueryable<Message> GetOutboxMessage(string mail);
        IQueryable<Message> GetTrashMessage(string mail);
        Message GetMessageById(int id);
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        void UpdateMessage(Message message);
    }
}
