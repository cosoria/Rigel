using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Chinook.DTO;
using Chinook.DataAccess.Context.All;
using Rigel.Data;
using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess.Repositories.All
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly IEntityFrameworkUnitOfWork _uow;

        public CustomerRepository(IEntityFrameworkUnitOfWork uow)
        {
            _uow = uow;
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
            return _uow.Context as IChinookAllEntitiesContext;
        }
    }
}