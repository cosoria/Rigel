using System.Data.Entity;

namespace Rigel.Data.EntityFramewok
{
    public class EntityFrameworkContext<TContext> : DbContext, IEntityFrameworkContext where TContext : DbContext
    {
        protected EntityFrameworkContext() : base()
        {
            Database.SetInitializer<TContext>(null);
        }

        protected EntityFrameworkContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<TContext>(null);
        }

        public void Save()
        {
            this.SaveChanges();
        }

        public void MarkAsAdded(object entity)
        {
            Entry(entity).State = System.Data.EntityState.Added;
        }

        public void MarkAsModified(object entity)
        {
            Entry(entity).State = System.Data.EntityState.Modified;
        }

        public void MarkAsDeleted(object entity)
        {
            Entry(entity).State = System.Data.EntityState.Deleted;
        }

        public void MarkAsUnchanged(object entity)
        {
            Entry(entity).State = System.Data.EntityState.Deleted;
        }
    }
}