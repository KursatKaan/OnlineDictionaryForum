using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Abstract
{
    public interface IWriterService
    {
        IQueryable<Writer> GetAllWriters(string keyword);
        Writer GetWriterByMail(string mail);
        Writer GetWriterById(int id);
        int GetWriterIdByMail(string mail);
        bool ValidateWriter(string mail, string password);
        void AddWriter(Writer writer);
        void DeleteWriter(Writer writer);
        void UpdateWriter(Writer writer);
    }
}
