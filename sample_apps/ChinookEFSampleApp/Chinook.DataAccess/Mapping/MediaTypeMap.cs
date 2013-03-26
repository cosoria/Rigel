using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Chinook.Entities;

namespace Chinook.DataAccess.Mapping
{
    public class MediaTypeMap : EntityTypeConfiguration<MediaType>
    {
        public MediaTypeMap()
        {
            // Primary Key
            HasKey(t => t.MediaTypeId);

            // Properties
            Property(t => t.MediaTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Name)
                .HasMaxLength(120);

            // Table & Column Mappings
            ToTable("MediaType");
            Property(t => t.MediaTypeId).HasColumnName("MediaTypeId");
            Property(t => t.Name).HasColumnName("Name");
        }
    }
}