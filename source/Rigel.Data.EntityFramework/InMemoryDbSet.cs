using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Rigel.Data.EntityFramewok
{
    public abstract class InMemoryDbSet<TEntity> : IDbSet<TEntity> where TEntity : class, new()
    {
        private readonly ObservableCollection<TEntity> _entities;
        private readonly IQueryable _query;

        protected InMemoryDbSet()
        {
            _entities = new ObservableCollection<TEntity>();
            _query = _entities.AsQueryable();
        }

        public TEntity Add(TEntity entity)
        {
            _entities.Add(entity);
            return entity;
        }

        public TEntity Attach(TEntity entity)
        {
            _entities.Add(entity);
            return entity;
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntity
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public TEntity Create()
        {
            return new TEntity();
        }

        public abstract TEntity Find(params object[] keyValues);

        public ObservableCollection<TEntity> Local
        {
            get { return _entities; }
        }

        public TEntity Remove(TEntity entity)
        {
            _entities.Remove(entity);
            return entity;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        public Type ElementType
        {
            get { return _query.ElementType; }
        }

        public Expression Expression
        {
            get { return _query.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return _query.Provider; }
        }
    }
}