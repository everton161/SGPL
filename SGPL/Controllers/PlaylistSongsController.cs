using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGPL.Data;
using SGPL.Models;

namespace SGPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistSongsController : ControllerBase
    {
        private readonly Context _context;

        public PlaylistSongsController(Context context)
        {
            _context = context;
        }

        // GET: api/PlaylistSongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistSong>>> GetPlaylistSong()
        {
          if (_context.PlaylistSong == null)
          {
              return NotFound();
          }
            return await _context.PlaylistSong.ToListAsync();
        }

        // GET: api/PlaylistSongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistSong>> GetPlaylistSong(int id)
        {
          if (_context.PlaylistSong == null)
          {
              return NotFound();
          }
            var playlistSong = await _context.PlaylistSong.FindAsync(id);

            if (playlistSong == null)
            {
                return NotFound();
            }

            return playlistSong;
        }

        // PUT: api/PlaylistSongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylistSong(int id, PlaylistSong playlistSong)
        {
            if (id != playlistSong.Id)
            {
                return BadRequest();
            }

            _context.Entry(playlistSong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistSongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlaylistSongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlaylistSong>> PostPlaylistSong(PlaylistSong playlistSong)
        {
          if (_context.PlaylistSong == null)
          {
              return Problem("Entity set 'Context.PlaylistSong'  is null.");
          }
            _context.PlaylistSong.Add(playlistSong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaylistSong", new { id = playlistSong.Id }, playlistSong);
        }

        // DELETE: api/PlaylistSongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylistSong(int id)
        {
            if (_context.PlaylistSong == null)
            {
                return NotFound();
            }
            var playlistSong = await _context.PlaylistSong.FindAsync(id);
            if (playlistSong == null)
            {
                return NotFound();
            }

            _context.PlaylistSong.Remove(playlistSong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaylistSongExists(int id)
        {
            return (_context.PlaylistSong?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
