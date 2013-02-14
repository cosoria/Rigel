using System;

namespace Rigel.Core.Domain
{
    public interface IDomainState<out TKey>
    {
        TKey Key { get; }
        byte[] ConcurrencyKey { get; }
        bool IsTransient { get; }
    }

    public interface IDomainState : IDomainState<Guid>
    {
    }
}