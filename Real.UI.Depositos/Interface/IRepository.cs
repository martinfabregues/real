using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Real.UI.Depositos.Interface
{
    public interface IRepository<T>
                    where T : class
    {
        IEnumerable<T> FindAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        T FindById(int id);
        int Add(T entity);
        bool Remover(int id);
        int Modify(T entity);
    }
}
