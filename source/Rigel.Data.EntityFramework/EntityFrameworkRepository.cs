using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rigel.Data.EntityFramewok
{
    public abstract class EntityFrameworkRepository<T> : IRepository<T> 
    {
        protected readonly IEntityFrameworkUnitOfWork _uow;

        protected EntityFrameworkRepository(IEntityFrameworkUnitOfWork uow)
        {
            _uow = uow;
        }

        public abstract T Get(object key);

        public abstract IEnumerable<T> GetAll();

        public abstract IEnumerable<T> GetAllMatching(Expression<Func<T, bool>> filter);
        
        public void Add(T entry)
        {
            _uow.Context.MarkAsAdded(entry);
        }

        public void Delete(object key)
        {
            var entry = Get(key);
            _uow.Context.MarkAsDeleted(entry);
        }

        public void Update(T entry)
        {
            _uow.Context.MarkAsModified(entry);
        }
    }
}