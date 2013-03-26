using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Chinook.Entities;

namespace Chinook.DataAccess.Mapping
{
    public class GenreMap : EntityTypeConfiguration<Genre>
    {
        public GenreMap()
        {
            // Primary Key
            HasKey(t => t.GenreId);

            // Properties
            Property(t => t.GenreId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Name)
                .HasMaxLength(120);

            // Table & Column Mappings
            ToTable("Genre");
            Property(t => t.GenreId).HasColumnName("GenreId");
            Property(t => t.Name).HasColumnName("Name");
        }
    }
}