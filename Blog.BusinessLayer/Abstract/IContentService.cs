using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Abstract
{
    public interface IContentService
    {
        IQueryable<Content> GetAllContents(string keyword);
        IQueryable<Content> GetContentsByWriter(int id,string keyword);
        IQueryable<Content> GetContentsByHeading(int id);
        Content GetContentById(int id);
        void AddContent(Content content);
        void DeleteContent(Content content);
        void UpdateContent(Content content);
    }
}
