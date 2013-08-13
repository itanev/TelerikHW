using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RipositoriesLayer
{
    public interface IRepsitory<T>
    {
        IQueryable<T> Find(Expression<Func<T, int, bool>> predicate);
        T Add(T entity);
        T Update(int id, T entity);
        void Delete(int id);
        T Get(int id);
        IQueryable<T> All();
    }
}
