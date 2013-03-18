using System.Data.Entity;
using Chinook.DataAccess.Mapping;
using Chinook.Domain;
using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess
{
    public interface IChinookSalesContext : IDbContext 
    {
        IDbSet<Customer> Customers { get; set; }
        IDbSet<Employee> Employees { get; set; }
        IDbSet<Invoice> Invoices { get; set; }
        IDbSet<InvoiceLine> InvoiceLines { get; set; }
    }
    
    public class ChinookSalesContext : ChinookContext<ChinookSalesContext>, IChinookSalesContext
    {
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Invoice> Invoices { get; set; }
        public IDbSet<InvoiceLine> InvoiceLines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new InvoiceMap());
            modelBuilder.Configurations.Add(new InvoiceLineMap());
        } 
    }

    
}