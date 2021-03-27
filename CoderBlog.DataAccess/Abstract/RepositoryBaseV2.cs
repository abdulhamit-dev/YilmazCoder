using CoderBlog.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CoderBlog.DataAccess.Abstract
{
    public class RepositoryBaseV2<T> where T : class
    {
        private DbContext db = new CoderBlogContext();
        private DbSet<T> dbSet;

        public RepositoryBaseV2()
        {
            dbSet = db.Set<T>();
        }

        public RepositoryBaseV2(CoderBlogContext context)
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
