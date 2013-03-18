using System.Data.Entity;
using Chinook.Domain;
using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess
{
    public partial class ChinookContext<TContext> : BaseDbContext<TContext> where TContext:DbContext,IDbContext
    {
        public ChinookContext() : base("Name=ChinookContext")
        {
        }
    }
}
