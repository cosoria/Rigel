using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess.Test.Context
{
    public class TestUnitOfWork : EntityFrameworkUnitOfWork 
    {
        public TestUnitOfWork() : base(new ChinookTestContext())
        {
        }
    }
}