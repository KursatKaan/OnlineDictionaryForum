using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Abstract
{
    public interface IAboutService
    {
        IQueryable<About> GetAllAbouts();
        About GetAboutById(int id);
        void AddAbout(About about);
        void DeleteAbout(About about);
        void UpdateAbout(About about);
    }
}
