using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Abstract
{
    public interface IContactService
    {
        IQueryable<Contact> GetAllContacts();
        Contact GetContactById(int id);
        void AddContact(Contact contact);
        void DeleteContact(Contact contact);
        void UpdateContact(Contact contact);
    }
}
