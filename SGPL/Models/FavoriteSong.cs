namespace SGPL.Models
{
    public class FavoriteSong
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User Users { get; set; } 
        public int SongId { get; set; }

        public Song Song { get; set; } 
        // Propriedades adicionais, se necessário...
    }

}
