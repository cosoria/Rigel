using System;

namespace Rigel.Data.EntityFramewok
{
    public interface IDbContext : IDataContext
    {
        void MarkAsAdded(IEntity entity);
        void MarkAsModified(IEntity entity);
        void MarkAsDeleted(IEntity entity);
        void MarkAsUnchanged(IEntity entity);    
    }
}