using Microsoft.EntityFrameworkCore;
using SGPL.Models;

namespace SGPL.Data
{
    public class Context : DbContext
    {
        public DbSet<Song> Musica { get; set; }

        public Context(DbContextOptions<Context> opcoes) : base(opcoes) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento um-para-muitos entre Playlist e PlaylistSong
            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.PlaylistSongs)
                .WithOne(ps => ps.Playlist)
                .HasForeignKey(ps => ps.PlaylistId);

            base.OnModelCreating(modelBuilder);

            // Relacionamento muitos-para-muitos entre Song e Genre
            modelBuilder.Entity<SongGenre>()
                .HasKey(sg => new { sg.SongId, sg.GenreId });

            modelBuilder.Entity<SongGenre>()
                .HasOne(sg => sg.Song)
                .WithMany(s => s.SongGenres)
                .HasForeignKey(sg => sg.SongId);

            modelBuilder.Entity<SongGenre>()
                .HasOne(sg => sg.Genre)
                .WithMany(g => g.SongGenres)
                .HasForeignKey(sg => sg.GenreId);

            base.OnModelCreating(modelBuilder);

            // Relacionamento um-para-muitos entre Artist e Album
            modelBuilder.Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.ArtistId);

 
        }
        public DbSet<SGPL.Models.Album>? Album { get; set; }
        public DbSet<SGPL.Models.Artist>? Artist { get; set; }
        public DbSet<SGPL.Models.FavoriteSong>? FavoriteSong { get; set; }
        public DbSet<SGPL.Models.Genre>? Genre { get; set; }
        public DbSet<SGPL.Models.Playlist>? Playlist { get; set; }
        public DbSet<SGPL.Models.User>? User { get; set; }
        public DbSet<SGPL.Models.PlaylistSong>? PlaylistSong { get; set; }

    }
}
