using System;

namespace Rigel.Core.Data
{

    public interface IEntity
    {
        int Id { get; }
    }

    public interface IDetachedEntity : IEntity
    {
        EntityState EntityState { get; set; }
    }
}