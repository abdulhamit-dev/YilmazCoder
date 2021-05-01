using CoderBlog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoderBlog.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        //private DbContext db;// = new CoderBlogContext();
        //private DbSet<T> dbSet;

        //public EfRepositoryBase()
        //{
        //    dbSet = db.Set<T>();
        //}

        //public EfRepositoryBase(TContext context)
        //{
        //    db = context;
        //    dbSet = db.Set<T>();
        //}

        //public T Get(Expression<Func<T, bool>> where)
        //{
        //    return dbSet.FirstOrDefault(where);
        //}
        //public List<T> GetList()
        //{
        //    return dbSet.ToList();
        //}
        //public List<T> OrderByDescendingList(Expression<Func<T, bool>> where)
        //{
        //    return dbSet.OrderByDescending(where).ToList();
        //}
        //public T OrderByDescendingFirst(Expression<Func<T, bool>> where)
        //{
        //    return dbSet.OrderByDescending(where).ToList().First();
        //}
        //public List<T> GetList(Expression<Func<T, bool>> where)
        //{
        //    return dbSet.Where(where).ToList();

        //}
        //public int Add(T obj)
        //{
        //    dbSet.Add(obj);
        //    return Save();
        //}
        //public int Update(T obj)
        //{
        //    return Save();
        //}
        //public int Delete(T obj)
        //{
        //    dbSet.Remove(obj);
        //    return Save();
        //}
        //public int Save()
        //{
        //    return db.SaveChanges();
        //}
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
