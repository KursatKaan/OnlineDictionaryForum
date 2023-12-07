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
    public class HeadingManager : IHeadingService
    {
        protected IHeadingDal _headingDal;

        // Constructor
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        // CREATE: HeadingManager --------------------------
        public void AddHeading(Heading heading)
        {
            _headingDal.Add(heading);
        }

        // DELETE: HeadingManager --------------------------
        public void DeleteHeading(Heading heading)
        {

            heading.HeadingStatus = !heading.HeadingStatus; //Tamamen silme işlemi yerine Başlık durumu değişir.
            _headingDal.Update(heading);
        }

        public Heading GetActiveHeadingById(int id)
        {
            return _headingDal.GetOne(x => x.Id == id && x.HeadingStatus == true);
        }


        // GET: HeadingManager --------------------------
        public IQueryable<Heading> GetAllHeadings(string keyword)
        {
            return _headingDal.GetAll(x => x.HeadingTitle.Contains(keyword)).OrderByDescending(x => x.HeadingDate);
        }

        public IQueryable<Heading> GetAllHeadingsForSidebar()
        {
            return _headingDal.GetAll(x => x.HeadingStatus == true).OrderByDescending(x => x.HeadingDate); //Sidebar için Tüm Başlıklar
        }

        public IQueryable<Heading> GetAllHeadingsForWriter(string keyword)
        {
            return _headingDal.GetAll(x => x.HeadingStatus == true && x.HeadingTitle.Contains(keyword)).OrderByDescending(x => x.HeadingDate); //Yazarın açtığı tüm başlıklar.
        }

        public Heading GetHeadingById(int id)
        {
            return _headingDal.GetOne(x => x.Id == id);
        }

        public IQueryable<Heading> GetHeadingsByCategory(int id)
        {
            return _headingDal.GetAll(x => x.CategoryId == id).OrderByDescending(x => x.HeadingDate); //Kategoriyle ilgili başlık.
        }

        public IQueryable<Heading> GetHeadingsByWriter(int id, string keyword)
        {
            return _headingDal.GetAll(x => x.WriterId == id && x.HeadingStatus == true && x.HeadingTitle.Contains(keyword)).OrderByDescending(x => x.HeadingDate); //Yazarla ilgili başlık.
        }

        // UPDATE: HeadingManager --------------------------
        public void UpdateHeading(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
