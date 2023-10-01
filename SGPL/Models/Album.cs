namespace SGPL.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
     
        public int ReleaseYear { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }

}
