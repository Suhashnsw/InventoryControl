using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InventoryControl.Infrastructure.Data.Repository
{
    public interface IRepository <TEntity> where TEntity : class 
    {
         IEnumerable<TEntity> Get();
         TEntity GetById(params object[] id);
         void Insert(TEntity entity);
         void Update(TEntity entityToUpdate);
         void Delete(int id);
         void Delete(TEntity entityToDelete);
         void Save();
         void Dispose();
    }
}