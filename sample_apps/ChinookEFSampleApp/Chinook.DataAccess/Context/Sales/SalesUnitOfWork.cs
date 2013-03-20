using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess.Context.Sales
{
    public class SalesUnitOfWork : EntityFrameworkUnitOfWork 
    {
        public SalesUnitOfWork() : base(new ChinookSalesContext())
        {
        }
    }
}