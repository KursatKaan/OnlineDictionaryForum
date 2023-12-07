using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Abstract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T,bool>> filter);
        IQueryable<T> GetAll();

        T GetOne(Expression<Func<T,bool>> filter);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
