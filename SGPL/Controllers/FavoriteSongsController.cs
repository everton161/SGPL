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
    public class FavoriteSongsController : ControllerBase
    {
        private readonly Context _context;

        public FavoriteSongsController(Context context)
        {
            _context = context;
        }

        // GET: api/FavoriteSongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteSong>>> GetFavoriteSong()
        {
          if (_context.FavoriteSong == null)
          {
              return NotFound();
          }
            return await _context.FavoriteSong.ToListAsync();
        }

        // GET: api/FavoriteSongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteSong>> GetFavoriteSong(int id)
        {
          if (_context.FavoriteSong == null)
          {
              return NotFound();
          }
            var favoriteSong = await _context.FavoriteSong.FindAsync(id);

            if (favoriteSong == null)
            {
                return NotFound();
            }

            return favoriteSong;
        }

        // PUT: api/FavoriteSongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteSong(int id, FavoriteSong favoriteSong)
        {
            if (id != favoriteSong.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteSong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteSongExists(id))
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

        // POST: api/FavoriteSongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavoriteSong>> PostFavoriteSong(FavoriteSong favoriteSong)
        {
          if (_context.FavoriteSong == null)
          {
              return Problem("Entity set 'Context.FavoriteSong'  is null.");
          }
            _context.FavoriteSong.Add(favoriteSong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoriteSong", new { id = favoriteSong.Id }, favoriteSong);
        }

        // DELETE: api/FavoriteSongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteSong(int id)
        {
            if (_context.FavoriteSong == null)
            {
                return NotFound();
            }
            var favoriteSong = await _context.FavoriteSong.FindAsync(id);
            if (favoriteSong == null)
            {
                return NotFound();
            }

            _context.FavoriteSong.Remove(favoriteSong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteSongExists(int id)
        {
            return (_context.FavoriteSong?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
