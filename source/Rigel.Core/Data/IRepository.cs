using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rigel.Data
{
    public interface IRepository<TEntry>
    {
        TEntry Get(object key);
        IEnumerable<TEntry> GetAll();
        IEnumerable<TEntry> GetAllMatching(Expression<Func<TEntry, bool>> filter);
        void Add(TEntry entry);
        void Delete(object key);
        void Update(TEntry entry);
    }
    
    public interface IRepository<TEntry, in TKey>
    {
        TEntry Get(TKey key);
        IEnumerable<TEntry> GetAll();
        IEnumerable<TEntry> GetAllMatching(Expression<Func<TEntry, bool>> filter);
        void Add(TKey key, TEntry entry);
        void Delete(TKey key);
        void Update(TKey key, TEntry entry);
    }
}