using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Chinook.DTO;

namespace Chinook.DataAccess.Mapping
{
    public class InvoiceLineMap : EntityTypeConfiguration<InvoiceLine>
    {
        public InvoiceLineMap()
        {
            // Primary Key
            HasKey(t => t.InvoiceLineId);

            // Properties
            Property(t => t.InvoiceLineId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            ToTable("InvoiceLine");
            Property(t => t.InvoiceLineId).HasColumnName("InvoiceLineId");
            Property(t => t.InvoiceId).HasColumnName("InvoiceId");
            Property(t => t.TrackId).HasColumnName("TrackId");
            Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            Property(t => t.Quantity).HasColumnName("Quantity");

            // Relationships
            HasRequired(t => t.Invoice)
                .WithMany(t => t.InvoiceLines)
                .HasForeignKey(d => d.InvoiceId);
            HasRequired(t => t.Track)
                .WithMany(t => t.InvoiceLines)
                .HasForeignKey(d => d.TrackId);
        }
    }
}