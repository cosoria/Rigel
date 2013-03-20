using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Chinook.DTO;

namespace Chinook.DataAccess.Mapping
{
    public class PlaylistMap : EntityTypeConfiguration<Playlist>
    {
        public PlaylistMap()
        {
            // Primary Key
            HasKey(t => t.PlaylistId);

            // Properties
            Property(t => t.PlaylistId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Name)
                .HasMaxLength(120);

            // Table & Column Mappings
            ToTable("Playlist");
            Property(t => t.PlaylistId).HasColumnName("PlaylistId");
            Property(t => t.Name).HasColumnName("Name");
        }
    }
}