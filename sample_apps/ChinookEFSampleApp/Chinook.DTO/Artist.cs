using System.Collections.Generic;
using Rigel.Data;

namespace Chinook.Entities
{
    public partial class Artist: IEntity
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