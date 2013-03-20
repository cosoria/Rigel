using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess.Context.All
{
    public class AllEntitiesUnitOfWork : EntityFrameworkUnitOfWork 
    {
        public AllEntitiesUnitOfWork() : base(new ChinookAllEntitiesContext())
        {
        }
    }
}