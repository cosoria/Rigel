using System.Collections.Generic;
using Rigel.Data;

namespace Chinook.Entities
{
    public partial class MediaType : IEntity
    {
        public MediaType()
        {
            this.Tracks = new List<Track>();
        }

        public long MediaTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}