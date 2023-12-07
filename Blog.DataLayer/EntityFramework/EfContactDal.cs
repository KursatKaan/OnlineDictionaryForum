using Blog.DataLayer.Abstract;
using Blog.DataLayer.Concrete;
using Blog.EntityLayer.Entities;

namespace Blog.DataLayer.EntityFramework
{
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
    }
}
