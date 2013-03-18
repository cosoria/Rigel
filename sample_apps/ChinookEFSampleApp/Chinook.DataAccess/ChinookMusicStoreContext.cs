using System.Data.Entity;
using Chinook.DataAccess.Mapping;
using Chinook.Domain;
using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess
{
    public interface IChinookMusicStoreContext : IDbContext
    {
        IDbSet<Album> Albums { get; set; }
        IDbSet<Artist> Artists { get; set; }
        IDbSet<Genre> Genres { get; set; }
        IDbSet<MediaType> MediaTypes { get; set; }
        IDbSet<Playlist> Playlists { get; set; }
        IDbSet<Track> Tracks { get; set; }
    }

    public class ChinookMusicStoreContext : ChinookContext<ChinookMusicStoreContext>, IChinookMusicStoreContext
    {
        public IDbSet<Album> Albums { get; set; }
        public IDbSet<Artist> Artists { get; set; }
        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<MediaType> MediaTypes { get; set; }
        public IDbSet<Playlist> Playlists { get; set; }
        public IDbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlbumMap());
            modelBuilder.Configurations.Add(new ArtistMap());
            modelBuilder.Configurations.Add(new GenreMap());
            modelBuilder.Configurations.Add(new InvoiceLineMap());
            modelBuilder.Configurations.Add(new PlaylistMap());
            modelBuilder.Configurations.Add(new TrackMap());
        }
    }
}