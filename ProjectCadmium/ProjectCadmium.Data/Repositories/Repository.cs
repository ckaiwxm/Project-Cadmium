using ProjectCadmium.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectCadmium.Model.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public T Get(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).SingleOrDefault();
        }

        public void Insert(T entity)
        {
            Context.Set<T>().Add(entity);
        }


        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }
}