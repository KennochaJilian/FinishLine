using FinishLine.Models.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinishLine.Repositories.Generics
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class, IIncludeObject, new()
    {
        protected DbContext context;
        private readonly DbSet<T> dbSet;


        public RepositoryGeneric(DbContext dbContextType)
        {
            context = dbContextType;
            dbSet = context.Set<T>();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            var query = dbSet.AsQueryable();
            foreach (var include in new T().IncludesNeeded())
            {
                query = query.Include(include);
            }
            if (predicate == null)
            {
                return query.ToList();
            }
            query = query.Where(predicate).AsQueryable();
            return query.ToList();
        }

        public T Get(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null) return dbSet.AsQueryable().FirstOrDefault();
            var query = dbSet.Where(predicate).AsQueryable();
            foreach (var include in new T().IncludesNeeded())
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault();
        }

        public T Add(T obj)
        {
            context.Attach(obj);
            dbSet.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public T Update(T obj)
        {
            context.Attach(obj);
            dbSet.Update(obj);
            context.SaveChanges();
            return obj;
        }

        public void Delete(T obj)
        {
            context.Attach(obj);
            dbSet.Remove(obj);
            context.SaveChanges();
        }

        public T Patch(JsonPatchDocument<T> tPatch, T obj)
        {
            tPatch.ApplyTo(obj);
            return Update(obj);
        }
    }
}
