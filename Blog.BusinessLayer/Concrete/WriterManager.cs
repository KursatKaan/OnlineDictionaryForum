using Blog.BusinessLayer.Abstract;
using Blog.BusinessLayer.Hasher;
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
    public class WriterManager : IWriterService
    {
        protected IWriterDal _writerDal;

        // Constructor
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        // CREATE: WriterManager --------------------------
        public void AddWriter(Writer writer)
        {
            _writerDal.Add(writer);
        }

        // DELETE: WriterManager --------------------------
        public void DeleteWriter(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        // GET: WriterManager -----------------------------
        public IQueryable<Writer> GetAllWriters(string keyword)
        {
            return _writerDal.GetAll(x=>x.Name.Contains(keyword) || x.Surname.Contains(keyword)).OrderBy(x => x.Name);
        }

        public Writer GetWriterById(int id)
        {
            return _writerDal.GetOne(x => x.Id == id);
        }

        public Writer GetWriterByMail(string mail)
        {
            return _writerDal.GetOne(x => x.Mail == mail);
        }

        public int GetWriterIdByMail(string mail)
        {
            return _writerDal.GetAll(x => x.Mail == mail && x.WriterStatus == true).Select(y => y.Id).FirstOrDefault();
        }

        // UPDATE: WriterManager --------------------------
        public void UpdateWriter(Writer writer)
        {
            _writerDal.Update(writer);
        }

        // LOGIN: WriterManager --------------------------
        public bool ValidateWriter(string mail, string password)
        {
            Writer writer = GetWriterByMail(mail);
            if (writer != null)
            {
                // Parola Hashing ve Doğrulama
                string hashedEnteredPassword = PasswordHasher.HashPassword(password);
                return hashedEnteredPassword == writer.Password;

            }
            return false;
        }
    }
}
