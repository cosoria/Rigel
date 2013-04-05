using System.Collections.Generic;
using Rigel.Data;

namespace Chinook.Entities
{
    public partial class Album : IEntity
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