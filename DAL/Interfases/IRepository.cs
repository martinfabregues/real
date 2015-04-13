using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Interfases
{
    public interface IRepository<T>
                            where T : class
    {
        IList<T> FindAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        T FindById(int id);
        int add(T newEntity);
        bool remove(int id);
        int Modify(T entity);
    }
}
