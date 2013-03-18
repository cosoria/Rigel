using System.Collections.Generic;

namespace Chinook.Domain
{
    public partial class Album
    {
        public Album()
        {
            this.Tracks = new List<Track>();
        }

        public long AlbumId { get; set; }
        public string Title { get; set; }
        public long ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
