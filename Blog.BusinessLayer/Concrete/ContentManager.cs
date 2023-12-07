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
    public class ContentManager : IContentService
    {
        protected IContentDal _contentDal;

        // Constructor
        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        // CREATE: ContentManager --------------------------
        public void AddContent(Content content)
        {
            _contentDal.Add(content);
        }

        // DELETE: ContentManager ---------------------------
        public void DeleteContent(Content content)
        {
            _contentDal.Delete(content);
        }

        // GET: ContentManager ------------------------------
        public IQueryable<Content> GetAllContents(string keyword)
        {
            return _contentDal.GetAll(x => x.ContentText.Contains(keyword) && x.ContentStatus == true).OrderByDescending(x => x.ContentDate);
        }

        public Content GetContentById(int id)
        {
            return _contentDal.GetOne(x => x.Id == id);
        }

        public IQueryable<Content> GetContentsByHeading(int id)
        {
            return _contentDal.GetAll(x => x.HeadingId == id && x.ContentStatus == true).OrderByDescending(x => x.ContentDate); //Başlıkla ilgili yazılar.
        }

        public IQueryable<Content> GetContentsByWriter(int id, string keyword)
        {
            return _contentDal.GetAll(x => x.WriterId == id && x.ContentText.Contains(keyword) && x.ContentStatus == true).OrderByDescending(x => x.ContentDate); //Yazarla ilgili yazılar.
        }

        // UPDATE: ContentManager ----------------------------
        public void UpdateContent(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
