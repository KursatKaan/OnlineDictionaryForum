using Blog.BusinessLayer.Abstract;
using Blog.DataLayer.Abstract;
using Blog.DataLayer.EntityFramework;
using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Concrete
{
    public class ContactManager:IContactService
    {
        protected IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void AddContact(Contact contact)
        {
            _contactDal.Add(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public IQueryable<Contact> GetAllContacts()
        {
            return _contactDal.GetAll().OrderByDescending(x => x.ContactDate);
        }

        public Contact GetContactById(int id)
        {
            return _contactDal.GetOne(x=> x.Id == id);
        }

        public void UpdateContact(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
