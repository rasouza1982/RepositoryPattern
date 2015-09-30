using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using RepositoryPattern.Infrastructure;

namespace RepositoryPattern.Data.Orm.nHibernate
{
    public class Repository<T> : IPersistRepository<T>,
        IReadOnlyRepository<T> where T : class //IEntityKey<TKey>
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public void Add(T entity)
        {
            _session.Save(entity);
        }

        public void Add(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                _session.Save(item);
            }
        }

        public void Update(T entity)
        {
            _session.Update(entity);
        }

        public void Delete(T entity)
        {
            _session.Delete(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _session.Delete(entity);
            }
        }

        public IQueryable<T> All()
        {
            return _session.Query<T>();
        }

        public T FindBy(Expression<Func<T, bool>> expression)
        {
            return FilterBy(expression).SingleOrDefault();
        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }

        public T FindBy(int id)
        {
            return _session.Get<T>(id);
        }
    }
}