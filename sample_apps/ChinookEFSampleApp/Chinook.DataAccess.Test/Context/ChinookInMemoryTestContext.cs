using System.Data.Entity;
using Chinook.DataAccess.Context.All;
using Chinook.Entities;
using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess.Test.Context
{
    public class ChinookInMemoryTestContext : InMemoryDbContext, IChinookAllEntitiesContext 
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

        public ChinookInMemoryTestContext()
        {
            Albums = new InMemoryAlbumDbSet();
            Artists = new InMemoryArtistDbSet();
            Customers = new InMemoryCustomersDbSet();
            Employees = new InMemorEmployeesDbSet();
            Genres = new InMemoryGenresDbSet();
            Invoices = new InMemoryInvoicesDbSet();
            InvoiceLines = new InMemoryInvoiceLinesDbSet();
            MediaTypes = new InMemoryMediaTypesDbSet();
            Playlists = new InMemoryPlaylistsDbSet();
            Tracks = new InMemoryTracksDbSet();
        }
    }
}