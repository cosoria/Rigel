using System.Collections.Generic;

namespace Chinook.DTO
{
    public partial class Track
    {
        public Track()
        {
            this.InvoiceLines = new List<InvoiceLine>();
            this.Playlists = new List<Playlist>();
        }

        public long TrackId { get; set; }
        public string Name { get; set; }
        public long? AlbumId { get; set; }
        public long MediaTypeId { get; set; }
        public long? GenreId { get; set; }
        public string Composer { get; set; }
        public long Milliseconds { get; set; }
        public long? Bytes { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Album Album { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        public virtual MediaType MediaType { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}