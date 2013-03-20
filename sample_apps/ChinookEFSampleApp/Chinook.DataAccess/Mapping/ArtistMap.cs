using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Chinook.DTO;

namespace Chinook.DataAccess.Mapping
{
    public class ArtistMap : EntityTypeConfiguration<Artist>
    {
        public ArtistMap()
        {
            // Primary Key
            HasKey(t => t.ArtistId);

            // Properties
            Property(t => t.ArtistId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Name)
                .HasMaxLength(120);

            // Table & Column Mappings
            ToTable("Artist");
            Property(t => t.ArtistId).HasColumnName("ArtistId");
            Property(t => t.Name).HasColumnName("Name");
        }
    }
}