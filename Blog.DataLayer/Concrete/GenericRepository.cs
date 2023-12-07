using Blog.DataLayer.Abstract;
using Blog.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Concrete
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected MyContext db = new MyContext();

        protected DbSet<T> _object;

        protected GenericRepository()
        {
            _object = db.Set<T>();
        }

        public void Add(T item)
        {
            var addedEntity = db.Entry(item);
            addedEntity.State = EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(T item)
        {
            var deletedEntity = db.Entry(item);
            deletedEntity.State = EntityState.Deleted;
            db.SaveChanges();
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter);
        }

        public IQueryable<T> GetAll()
        {
            return _object;
        }

        public void Update(T item)
        {
            var updatedEntity = db.Entry(item);
            updatedEntity.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
