using Blog.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        IQueryable<Heading> GetAllHeadings(string keyword);
        IQueryable<Heading> GetAllHeadingsForWriter(string keyword);
        IQueryable<Heading> GetAllHeadingsForSidebar();
        IQueryable<Heading> GetHeadingsByWriter(int id, string keyword);
        IQueryable<Heading> GetHeadingsByCategory(int id);
        Heading GetHeadingById(int id);
        Heading GetActiveHeadingById(int id);
        void AddHeading(Heading heading);
        void DeleteHeading(Heading heading);
        void UpdateHeading(Heading heading);
    }
}
