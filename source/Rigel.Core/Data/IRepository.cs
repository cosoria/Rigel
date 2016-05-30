using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rigel.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class, IEntity
    {
        TEntity Get(object key);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllMatching(Expression<Func<TEntity, bool>> filter);
        
        TEntity Add(TEntity entry);
        TEntity Update(TEntity entry);

        void Delete(object key);
    }
}