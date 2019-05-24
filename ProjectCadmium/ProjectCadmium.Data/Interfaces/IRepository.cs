using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectCadmium.Model.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(Guid id);
        List<T> GetAll();
        T Find(Expression<Func<T, bool>> predicate);

        void Insert(T entity);
        void Delete(T entity);
    }
}
