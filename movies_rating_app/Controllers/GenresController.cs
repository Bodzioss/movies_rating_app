using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesRatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly DataContext _context;
        public GenresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            if(_context.Genres == null)
            {
                return NotFound();
            }
            return await _context.Genres.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            if(_context.Genres == null)
            {
                return NotFound();
            }
            var genre = await _context.Genres.FindAsync(id);

            if(genre == null)
            {
                return NotFound();
            }
            return genre;
        }

        [HttpPut("id")]
        public async Task<ActionResult<Genre>> PutGenre(int id,Genre genre)
        {
            if(id != genre.ID)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!GenreExists(id))
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


        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            if (_context.Genres == null)
            {
                return Problem("Entity set 'DataContext.Genres'  is null.");
            }
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.ID }, genre);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Genre>> DeleteGenre(int id)
        {
            if(_context.Genres == null)
            {
                return Problem("Entity set 'DataContext.Genres' is null.");
            }
            var genre = await _context.Genres.FindAsync(id);
            if(genre == null)
            {
                return NotFound();
            }
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenreExists(int id)
        {
            return (_context.Genres?.Any(ep => ep.ID == id)).GetValueOrDefault();
        }
    }
}
