using System;
using System.Collections.Generic;

namespace Rigel.Core.Data
{
    public class InMemoryRepository<TEntry, TKey> : IRepository<TEntry, TKey>
    {
        private readonly Dictionary<TKey,TEntry> _entries;

        public InMemoryRepository()
        {
            _entries = new Dictionary<TKey, TEntry>();
        }

        public virtual TEntry Get(TKey key)
        {
            if (!_entries.ContainsKey(key))
            {
                return default(TEntry);
            }

            return _entries[key];
        }

        public virtual IEnumerable<TEntry> GetAll()
        {
            return _entries.Values;
        }

        public virtual void Add(TKey key, TEntry entry)
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

        public virtual void Update(TKey key,TEntry entry)
        {
            if (_entries.ContainsKey(key))
            {
                _entries[key] = entry;
            } 
        }
    }

    public class InMemoryRepository<TEntry> : InMemoryRepository<Guid, TEntry>
    {
    }
}