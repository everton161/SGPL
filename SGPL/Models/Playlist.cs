﻿namespace SGPL.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<PlaylistSong> PlaylistSongs { get; set; }
    }

}
