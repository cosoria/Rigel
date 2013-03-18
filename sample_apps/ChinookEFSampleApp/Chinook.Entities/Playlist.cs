using System.Collections.Generic;

namespace Chinook.Domain
{
    public partial class Playlist
    {
        public Playlist()
        {
            this.Tracks = new List<Track>();
        }

        public long PlaylistId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
