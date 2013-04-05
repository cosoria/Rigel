using System;
using System.Collections.Generic;
using Rigel.Data;

namespace Chinook.Entities
{
    public partial class Invoice : IEntity
    {
        public Invoice()
        {
            this.InvoiceLines = new List<InvoiceLine>();
        }

        public long InvoiceId { get; set; }
        public long CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public decimal Total { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}