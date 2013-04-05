using System.Collections.Generic;
using Rigel.Data;

namespace Chinook.Entities
{
    public partial class Playlist : IEntity
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