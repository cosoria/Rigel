using System.Collections.Generic;

namespace Chinook.Domain
{
    public partial class Genre
    {
        public Genre()
        {
            this.Tracks = new List<Track>();
        }

        public long GenreId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
