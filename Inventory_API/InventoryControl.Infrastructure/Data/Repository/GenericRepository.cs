using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using InventoryControl.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace InventoryControl.Infrastructure.Data
{
    public class GenericRepository <TEntity>: IRepository <TEntity> where TEntity : class 
    {
        internal InventoryContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository (InventoryContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }


        public virtual IEnumerable<TEntity> Get()
        {
            return dbSet.ToList();
            
        }

        public virtual TEntity GetById(params object[] id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
           context.Dispose();
        }
    }
  
}