using System.Data.Entity;
using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess.Context
{
    public partial class ChinookContext<TContext> : EntityFrameworkContext<TContext> where TContext : DbContext, IEntityFrameworkContext
    {
        public ChinookContext() 
            : base("Name=ChinookContext")
        {
        }
    }
}
