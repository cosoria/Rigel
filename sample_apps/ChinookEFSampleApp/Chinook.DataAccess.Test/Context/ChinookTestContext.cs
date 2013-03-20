using System.Data.Entity;
using Chinook.DataAccess.Context.All;

namespace Chinook.DataAccess.Test.Context
{
    public class ChinookTestContext : ChinookAllEntitiesContext
    {
        public ChinookTestContext() : base()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ChinookTestContext>());

            // Force database initialization 
            Database.Initialize(true);
        }
    }
}