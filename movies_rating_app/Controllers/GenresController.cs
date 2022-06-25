using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.GenreDtos;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesRatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public GenresController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            try
            {
                var genres = await _repository.Genre.GetAllGenresAsync();

                _logger.LogInfo($"Returned all genres from database.");

                var genresResult = _mapper.Map<IEnumerable<GenreDto>>(genres);

                return Ok(genresResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetGenresAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("{id}", Name = "GenreById")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            try
            {
                var genre = await _repository.Genre.GetGenreByIdAsync(id);
                if (genre is null)
                {
                    _logger.LogError($"Genre with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned genre with id: {id}");
                    var genreResult = _mapper.Map<GenreDto>(genre);
                    return Ok(genreResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetGenreByIdAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] GenreForCreationDto genre)
        {
            try
            {
                if (genre is null)
                {
                    _logger.LogError("Genre object sent from client is null.");
                    return BadRequest("Genre object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid genre object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var genreEntity = _mapper.Map<Genre>(genre);
                _repository.Genre.CreateGenre(genreEntity);
                await _repository.SaveAsync();
                var createdGenre = _mapper.Map<GenreDto>(genreEntity);
                return CreatedAtRoute("GenreById", new { id = createdGenre.ID }, createdGenre);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateGenre action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] GenreForUpdateDto genre)
        {
            try
            {
                if (genre is null)
                {
                    _logger.LogError("Genre object sent from client is null.");
                    return BadRequest("Genre object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid genre object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var genreEntity =await _repository.Genre.GetGenreByIdAsync(id);
                if (genreEntity is null)
                {
                    _logger.LogError($"Genre with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(genre, genreEntity);
                _repository.Genre.UpdateGenre(genreEntity);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateGenre action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            try
            {
                var genre = await _repository.Genre.GetGenreByIdAsync(id);
                if (genre == null)
                {
                    _logger.LogError($"Genre with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.Genre.DeleteGenre(genre);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteGenre action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
