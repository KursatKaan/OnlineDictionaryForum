using Blog.BusinessLayer.Abstract;
using Blog.DataLayer.Abstract;
using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        protected IAboutDal _aboutDal;

        // Constructor
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        // CREATE: AboutManager --------------------------
        public void AddAbout(About about)
        {
            _aboutDal.Add(about);
        }

        // DELETE: AboutManager --------------------------
        public void DeleteAbout(About about)
        {
            _aboutDal.Delete(about);
        }

        // GET: AboutManager -----------------------------
        public About GetAboutById(int id)
        {
            return _aboutDal.GetOne(x=> x.Id == id);
        }

        public IQueryable<About> GetAllAbouts()
        {
            return _aboutDal.GetAll();
        }

        // UPDATE: AboutManager --------------------------
        public void UpdateAbout(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
