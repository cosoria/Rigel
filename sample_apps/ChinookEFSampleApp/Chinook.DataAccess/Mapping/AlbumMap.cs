using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Chinook.DTO;

namespace Chinook.DataAccess.Mapping
{
    public class AlbumMap : EntityTypeConfiguration<Album>
    {
        public AlbumMap()
        {
            // Primary Key
            HasKey(t => t.AlbumId);

            // Properties
            Property(t => t.AlbumId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(160);

            // Table & Column Mappings
            ToTable("AlbumState");
            Property(t => t.AlbumId).HasColumnName("AlbumId");
            Property(t => t.Title).HasColumnName("Title");
            Property(t => t.ArtistId).HasColumnName("ArtistId");

            // Relationships
            HasRequired(t => t.Artist)
                .WithMany(t => t.Albums)
                .HasForeignKey(d => d.ArtistId);
        }
    }
}