using System;

namespace Rigel.Core.Domain
{
    //public class DomainState<TKey> : IDomainState<TKey>
    //{
    //    public TKey Key { get; private set; }
    //    public byte[] ConcurrencyKey { get; private set; }
    //    public bool IsTransient { get; private set; }

    //    public DomainState() : this(default(TKey), new byte[]{})
    //    {
    //        IsTransient = true;
    //    }

    //    public DomainState(TKey key, byte[] concurrencyKey)
    //    {
    //        Key = key;
    //        ConcurrencyKey = concurrencyKey;
    //        IsTransient = false;
    //    }
    //}

    //public class DomainState : DomainState<Guid>
    //{
    //    public DomainState() : this(Guid.Empty, new byte[]{})
    //    {
    //    }

    //    public DomainState(Guid key, byte[] concurrencyKey) : base(key, concurrencyKey)
    //    {
    //    }
    //}
}