using System.Data.Entity;

namespace Rigel.Data.EntityFramewok
{
    public class BaseDbContext<TContext> : DbContext, IDbContext where TContext : DbContext
    {
        protected BaseDbContext()
        {
            Database.SetInitializer<TContext>(null);
        }

        public void Save()
        {
            this.SaveChanges();
        }

        public void MarkAsAdded(IEntity entity)
        {
            Entry(entity).State = System.Data.EntityState.Added;
        }

        public void MarkAsModified(IEntity entity)
        {
            Entry(entity).State = System.Data.EntityState.Modified;
        }

        public void MarkAsDeleted(IEntity entity)
        {
            Entry(entity).State = System.Data.EntityState.Deleted;
        }

        public void MarkAsUnchanged(IEntity entity)
        {
            Entry(entity).State = System.Data.EntityState.Deleted;
        }
    }
}