using System;
using System.Collections.Generic;

namespace Rigel.Core.Data
{
    public interface IRepository<TEntry, in TKey>
    {
        TEntry Get(TKey key);
        IEnumerable<TEntry> GetAll();

        void Add(TKey key, TEntry entry);
        void Delete(TKey key);
        void Update(TKey key, TEntry entry);
    }

    public interface IRepository<TEntry> : IRepository<TEntry, Guid>
    {
    }
}