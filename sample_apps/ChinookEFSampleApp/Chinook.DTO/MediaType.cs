using System.Collections.Generic;

namespace Chinook.DTO
{
    public partial class MediaType
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