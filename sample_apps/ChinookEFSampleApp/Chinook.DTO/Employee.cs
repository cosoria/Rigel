using System;
using System.Collections.Generic;
using Rigel.Data;

namespace Chinook.Entities
{
    public partial class Employee : IEntity
    {
        public Employee()
        {
            this.Customers = new List<Customer>();
            this.Subordinates = new List<Employee>();
        }

        public long EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public long? ReportsTo { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Subordinates { get; set; }
        public virtual Employee Manager { get; set; }
    }

}