using System.Data.Entity;

namespace Rigel.Data.EntityFramewok
{
    public static class DbContextExtensions
    {
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IEntity>())
            {
                entry.State = entry.Entity.EntityState.ToEntityFrameworkState();
            }
        }
    }
}