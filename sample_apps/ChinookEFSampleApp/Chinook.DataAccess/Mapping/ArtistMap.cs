using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Chinook.Domain;

namespace Chinook.DataAccess.Mapping
{
    public class ArtistMap : EntityTypeConfiguration<Artist>
    {
        public ArtistMap()
        {
            // Primary Key
            this.HasKey(t => t.ArtistId);

            // Properties
            this.Property(t => t.ArtistId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(120);

            // Table & Column Mappings
            this.ToTable("Artist");
            this.Property(t => t.ArtistId).HasColumnName("ArtistId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
