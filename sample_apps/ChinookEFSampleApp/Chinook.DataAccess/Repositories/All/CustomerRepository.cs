using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Chinook.DataAccess.Context.All;
using Chinook.Entities;
using Rigel.Core;
using Rigel.Data;
using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess.Repositories.All
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }

    public class CustomerRepository : EntityFrameworkRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IEntityFrameworkUnitOfWork uow) : base(uow)
        {
            Ensure.NotNull(() => GetContext());
        }

        public override Customer Get(object key)
        {
            return GetContext().Customers.Find(key);
        }

        public override IEnumerable<Customer> GetAll()
        {
            return GetContext().Customers.ToArray();
        }

        public override IEnumerable<Customer> GetAllMatching(Expression<Func<Customer, bool>> filter)
        {
            return GetContext().Customers.Where(filter).ToArray();
        }

        private ChinookAllEntitiesContext GetContext()
        {
            return _context as ChinookAllEntitiesContext;
        }
    }
}