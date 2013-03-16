using System.ComponentModel;

namespace Rigel.Data.EntityFramewok
{
    public static class EntityExtensions
    {
        public static System.Data.EntityState ToEntityFrameworkState(this Rigel.Data.EntityState state)
        {
            switch (state)
            {
                case EntityState.Unchanged:
                    return System.Data.EntityState.Unchanged;
                case EntityState.Added:
                    return System.Data.EntityState.Added;
                case EntityState.Modified:
                    return System.Data.EntityState.Modified;
                case EntityState.Deleted:
                    return System.Data.EntityState.Deleted;
            }

            throw new InvalidEnumArgumentException("Entity State is not supported");
        }
    }
}