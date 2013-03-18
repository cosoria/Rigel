using System.Data.Entity;
using Chinook.DataAccess.Mapping;
using Chinook.Domain;
using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess
{
    public interface IChinookAllEntitiesContext : IDbContext
    {
       IDbSet<Album> Albums { get; set; }
       IDbSet<Artist> Artists { get; set; }
       IDbSet<Customer> Customers { get; set; }
       IDbSet<Employee> Employees { get; set; }
       IDbSet<Genre> Genres { get; set; }
       IDbSet<Invoice> Invoices { get; set; }
       IDbSet<InvoiceLine> InvoiceLines { get; set; }
       IDbSet<MediaType> MediaTypes { get; set; }
       IDbSet<Playlist> Playlists { get; set; }
       IDbSet<Track> Tracks { get; set; }
    }
    
    public partial class ChinookAllEntitiesContext : ChinookContext<ChinookAllEntitiesContext>, IChinookAllEntitiesContext
    {
        public IDbSet<Album> Albums { get; set; }
        public IDbSet<Artist> Artists { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Invoice> Invoices { get; set; }
        public IDbSet<InvoiceLine> InvoiceLines { get; set; }
        public IDbSet<MediaType> MediaTypes { get; set; }
        public IDbSet<Playlist> Playlists { get; set; }
        public IDbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlbumMap());
            modelBuilder.Configurations.Add(new ArtistMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new GenreMap());
            modelBuilder.Configurations.Add(new InvoiceMap());
            modelBuilder.Configurations.Add(new InvoiceLineMap());
            modelBuilder.Configurations.Add(new MediaTypeMap());
            modelBuilder.Configurations.Add(new PlaylistMap());
            modelBuilder.Configurations.Add(new TrackMap());
        }
    }
}