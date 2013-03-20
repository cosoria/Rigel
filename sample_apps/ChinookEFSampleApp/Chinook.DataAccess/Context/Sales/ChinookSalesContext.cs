using System.Data.Entity;
using Chinook.DTO;
using Chinook.DataAccess.Mapping;
using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess.Context.Sales
{
    public interface IChinookSalesContext : IEntityFrameworkContext 
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