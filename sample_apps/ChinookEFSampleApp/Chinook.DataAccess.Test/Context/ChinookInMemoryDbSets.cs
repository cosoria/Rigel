using System;
using System.Linq;
using Chinook.Entities;
using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess.Test.Context
{
    public class InMemoryTracksDbSet : InMemoryDbSet<Track>
    {
        public override Track Find(params object[] keyValues)
        {
            return _entities.SingleOrDefault(a => a.TrackId == Convert.ToInt32(keyValues[0]));
        }
    }

    public class InMemoryPlaylistsDbSet : InMemoryDbSet<Playlist>
    {
        public override Playlist Find(params object[] keyValues)
        {
            return _entities.SingleOrDefault(a => a.PlaylistId == Convert.ToInt32(keyValues[0]));
        }
    }

    public class InMemoryMediaTypesDbSet : InMemoryDbSet<MediaType>
    {
        public override MediaType Find(params object[] keyValues)
        {
            return _entities.SingleOrDefault(a => a.MediaTypeId == Convert.ToInt32(keyValues[0]));
        }
    }

    public class InMemoryInvoiceLinesDbSet : InMemoryDbSet<InvoiceLine>
    {
        public override InvoiceLine Find(params object[] keyValues)
        {
            return _entities.SingleOrDefault(a => a.InvoiceLineId == Convert.ToInt32(keyValues[0]));
        }
    }

    public class InMemoryInvoicesDbSet : InMemoryDbSet<Invoice>
    {
        public override Invoice Find(params object[] keyValues)
        {
            return _entities.SingleOrDefault(a => a.InvoiceId == Convert.ToInt32(keyValues[0]));
        }
    }

    public class InMemoryGenresDbSet : InMemoryDbSet<Genre>
    {
        public override Genre Find(params object[] keyValues)
        {
            return _entities.SingleOrDefault(a => a.GenreId == Convert.ToInt32(keyValues[0]));
        }
    }

    public class InMemorEmployeesDbSet : InMemoryDbSet<Employee>
    {
        public override Employee Find(params object[] keyValues)
        {
            return _entities.SingleOrDefault(a => a.EmployeeId == Convert.ToInt32(keyValues[0]));
        }
    }

    public class InMemoryCustomersDbSet : InMemoryDbSet<Customer>
    {
        public override Customer Find(params object[] keyValues)
        {
            return _entities.SingleOrDefault(a => a.CustomerId == Convert.ToInt32(keyValues[0]));
        }
    }

    public class InMemoryArtistDbSet : InMemoryDbSet<Artist>
    {
        public override Artist Find(params object[] keyValues)
        {
            return _entities.SingleOrDefault(a => a.ArtistId == Convert.ToInt32(keyValues[0]));
        }
    }

    public class InMemoryAlbumDbSet : InMemoryDbSet<Album>
    {
        public override Album Find(params object[] keyValues)
        {
            return _entities.SingleOrDefault(a => a.AlbumId == Convert.ToInt32(keyValues[0]));
        }
    }
}