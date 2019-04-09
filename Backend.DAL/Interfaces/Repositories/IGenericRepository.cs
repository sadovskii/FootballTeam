using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Backend.DAL.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetBy(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
