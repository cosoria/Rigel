using System;

namespace Rigel.Data.EntityFramewok
{
    public interface IEntityFrameworkContext : IDataContext
    {
        void MarkAsAdded(object entity);
        void MarkAsModified(object entity);
        void MarkAsDeleted(object entity);
        void MarkAsUnchanged(object entity);    
    }
}