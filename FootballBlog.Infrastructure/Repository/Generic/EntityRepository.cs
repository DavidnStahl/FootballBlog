using FootballBlog.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FootballBlog.Infrastructure.Repository.Generic
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private readonly BlogContext _context;
        public EntityRepository(BlogContext context)
        {
            _context = context;
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public List<T> FindAllBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> entities = _context.Set<T>().Where(predicate);

            return entities.ToList();

        }

        public T FindSingleBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);

        }

        public virtual bool Add(T entity)
        {
            _context.Set<T>().Add(entity);

            return true;
        }

        public virtual bool Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

            return true;
        }

        public virtual bool Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return true;
        }

        public virtual bool Save()
        {
            _context.SaveChanges();

            return true;
        }

        public virtual T FindById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public bool AddRange(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);

            return true;
        }

        public bool EditRange(List<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);

            return true;
        }
    }
}
