using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rigel.Core;

namespace Rigel.Data.EntityFramewok
{
    public abstract class EntityFrameworkRepository<TEntity> : Disposable, IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly IEntityFrameworkUnitOfWork _uow;
        protected readonly IEntityFrameworkContext _context;

        protected EntityFrameworkRepository(IEntityFrameworkUnitOfWork uow)
        {
            _uow = uow;
            _context = _uow.Context;
        }

        public abstract TEntity Get(object key);

        public abstract IEnumerable<TEntity> GetAll();

        public abstract IEnumerable<TEntity> GetAllMatching(Expression<Func<TEntity, bool>> filter);
        
        public void Add(TEntity entry)
        {
            _context.MarkAsAdded(entry);
        }

        public void Delete(object key)
        {
            var entry = Get(key);
            _context.MarkAsDeleted(entry);
        }

        public void Update(TEntity entry)
        {
            _context.MarkAsModified(entry);
        }
    }
}