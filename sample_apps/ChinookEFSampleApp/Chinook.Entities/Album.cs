namespace Chinook.Domain
{
    public partial class Album
    {
        private Entities.Album _album;

        public Album(Entities.Album album)
        {
            _album = album;
        }
    }
}
