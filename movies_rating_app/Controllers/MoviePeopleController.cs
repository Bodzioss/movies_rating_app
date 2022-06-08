using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesRatingApp.API.Models;

namespace MoviesRatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviePeopleController : ControllerBase
    {
        private readonly DataContext _context;

        public MoviePeopleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoviePerson>>> GetMoviePeople()
        {
            if(_context.MoviePeople == null)
            {
                return NotFound();
            }
            return await _context.MoviePeople.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<ActionResult<MoviePerson>> GetMoviePeople(int id)
        {
            if (_context.MoviePeople == null)
            {
                return NotFound();
            }
            var moviePeople = await _context.MoviePeople.FindAsync(id);
            if(moviePeople == null)
            {
                return NotFound();
            }

            return moviePeople;
        }

        [HttpPut("id")]
        public async Task<ActionResult<MoviePerson>> PutMoviePeople(int id, MoviePerson moviePerson)
        {
            if (id == moviePerson.ID)
            {
                return BadRequest();
            }

            _context.Entry(moviePerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!MoviePersonExist(id))
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
        public async Task<ActionResult<MoviePerson>> PostMoviePeople(MoviePerson moviePerson)
        {
            if(_context.MoviePeople == null)
            {
                return NotFound();
            }

            _context.MoviePeople.Add(moviePerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoviePeople", new { id = moviePerson.ID }, moviePerson);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<MoviePerson>> DeleteMoviePeople(int id)
        {
            if(_context.MoviePeople == null)
            {
                return NotFound();
            }

            var moviePerson = await _context.MoviePeople.FindAsync(id);

            if(moviePerson == null)
            {
                return NotFound();
            }

            _context.MoviePeople.Remove(moviePerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool MoviePersonExist(int id)
        {
            throw new NotImplementedException();
        }

    }
}
