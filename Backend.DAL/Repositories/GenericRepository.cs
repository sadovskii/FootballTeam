using Backend.DAL.Entities;
using Backend.DAL.Interfaces;
using Backend.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Backend.DAL.Repositories
{
    public abstract class GenericRepository<C, T> : IGenericRepository<T>
        where T : BaseEntity
        where C : DbContext
    {

        public C context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public GenericRepository(C context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T GetBy(Expression<Func<T, bool>> predicate)
        {
            var a = entities.FirstOrDefault(predicate);
            return a;
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");


            entities.Update(entity);
            context.SaveChanges();
        }

        public void InsertOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        public abstract void Delete(int id);
    }
}
