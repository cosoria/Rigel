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

    public class CustomerRepository : ICustomerRepository
    {
        private readonly IChinookAllEntitiesContext _context;

        public CustomerRepository(IEntityFrameworkUnitOfWork uow)
        {
            _context = uow.Context as IChinookAllEntitiesContext;
            Ensure.NotNull(() => _context);
        }
        
        public Customer Get(object key)
        {
            return GetContext().Customers.Find(key);
        }

        public IEnumerable<Customer> GetAll()
        {
            return GetContext().Customers.ToArray();
        }

        public IEnumerable<Customer> GetAllMatching(Expression<Func<Customer, bool>> filter)
        {
            return GetContext().Customers.Where(filter).ToArray();
        }

        public void Add(Customer entry)
        {
            GetContext().MarkAsAdded(entry);
        }

        public void Delete(object key)
        {
            var entry = Get(key);
            GetContext().MarkAsDeleted(entry);
        }

        public void Update(Customer entry)
        {
            GetContext().MarkAsModified(entry);
        }

        private IChinookAllEntitiesContext GetContext()
        {
            return _context;
        }
    }
}