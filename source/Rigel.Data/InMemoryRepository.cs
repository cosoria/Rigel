using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Rigel.Core;
using Rigel.Core.Data;

namespace Rigel.Data
{

    public class InMemoryRepository<TEntity> : Disposable, IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly Dictionary<object, TEntity> _entries;

        public InMemoryRepository()
        {
            _entries = new Dictionary<object, TEntity>();
        }

        public TEntity Get(object key)
        {
            if (!_entries.ContainsKey(key))
            {
                return default(TEntity);
            }

            return _entries[key];
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entries.Values;
        }

        public IEnumerable<TEntity> GetAllMatching(Expression<Func<TEntity, bool>> filter)
        {
            return _entries.Values.AsQueryable().Where(filter).ToArray();
        }

        public TEntity Add(TEntity entry)
        {
            _entries.Add(Guid.NewGuid(), entry);
            return entry;
        }

        public void Delete(object key)
        {
            if (_entries.ContainsKey(key))
            {
                _entries.Remove(key);
            }
        }

        public TEntity Update(TEntity entry)
        {
            return entry;
        }

        protected override void DisposeManagedResources()
        {
            base.DisposeManagedResources();
            _entries.Clear();
        }
    }

    /*
    public class InMemoryRepository<TEntity, TKey> : Disposable, IRepository<TEntity, TKey> where TEntity : class, IEntity
    {
        private readonly Dictionary<TKey,TEntity> _entries;

        public InMemoryRepository()
        {
            _entries = new Dictionary<TKey, TEntity>();
        }

        public virtual TEntity Get(TKey key)
        {
            if (!_entries.ContainsKey(key))
            {
                return default(TEntity);
            }

            return _entries[key];
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entries.Values;
        }

        public IEnumerable<TEntity> GetAllMatching(Expression<Func<TEntity, bool>> filter)
        {
            return _entries.Values.AsQueryable().Where(filter).ToArray();
        }

        public virtual void Add(TKey key, TEntity entry)
        {
            if (_entries.ContainsKey(key))
            {
                _entries[key] = entry;
            }
            else
            {
                _entries.Add(key, entry);
            }
        }

        public virtual void Delete(TKey key)
        {
            if (_entries.ContainsKey(key))
            {
                _entries.Remove(key);
            }
        }

        public virtual void Update(TKey key,TEntity entry)
        {
            if (_entries.ContainsKey(key))
            {
                _entries[key] = entry;
            } 
        }

        protected override void DisposeManagedResources()
        {
            base.DisposeManagedResources();
            _entries.Clear();
        }
    }
    */
}