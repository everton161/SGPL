namespace SGPL.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int DurationInSeconds { get; set; }
        public string Genre { get; set; }

        public List<SongGenre> SongGenres { get; set; }

    }
}
