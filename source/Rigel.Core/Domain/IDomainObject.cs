using System;

namespace Rigel.Core.Domain
{
    public interface IDomainObject<out TKey>
    {
        IDomainState<TKey> State { get; }
    }

    public interface IDomainObject : IDomainState
    {
        IDomainState State { get; }
    }
}