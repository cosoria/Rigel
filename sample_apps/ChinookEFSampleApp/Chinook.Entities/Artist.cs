using System.Collections.Generic;

namespace Chinook.Domain
{
    public partial class Artist
    {
        public Artist()
        {
            this.Albums = new List<Album>();
        }

        public long ArtistId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
