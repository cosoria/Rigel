using Rigel.Core;

namespace Rigel.Data.EntityFramewok
{
    public class InMemoryDbContext : Disposable, IEntityFrameworkContext
    {
        public void Save()
        {
            // Nothing to do 
        }

        public void MarkAsAdded(object entity)
        {
            // Nothing to do 
        }

        public void MarkAsModified(object entity)
        {
            // Nothing to do 
        }

        public void MarkAsDeleted(object entity)
        {
            // Nothing to do 
        }

        public void MarkAsUnchanged(object entity)
        {
            // Nothing to do 
        }
    }
}