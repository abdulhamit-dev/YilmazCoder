using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoderBlog.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<T, TContext> 
        where T : class,new()
        where TContext : DbContext,new()
    {
        private DbContext db;// = new CoderBlogContext();
        private DbSet<T> dbSet;

        public EfRepositoryBase()
        {
            dbSet = db.Set<T>();
        }

        public EfRepositoryBase(TContext context)
        {
            db = context;
            dbSet = db.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.FirstOrDefault(where);
        }
        public List<T> GetList()
        {
            return dbSet.ToList();
        }
        public List<T> OrderByDescendingList(Expression<Func<T, bool>> where)
        {
            return dbSet.OrderByDescending(where).ToList();
        }
        public T OrderByDescendingFirst(Expression<Func<T, bool>> where)
        {
            return dbSet.OrderByDescending(where).ToList().First();
        }
        public List<T> GetList(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();

        }
        public int Add(T obj)
        {
            dbSet.Add(obj);
            return Save();
        }
        public int Update(T obj)
        {
            return Save();
        }
        public int Delete(T obj)
        {
            dbSet.Remove(obj);
            return Save();
        }
        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
