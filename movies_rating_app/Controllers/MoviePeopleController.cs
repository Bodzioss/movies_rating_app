using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects.MoviePersonDtos;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesRatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviePeopleController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public MoviePeopleController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/MoviePeople
        [HttpGet]
        public async Task<IActionResult> GetAllMoviePeople()
        {
            try
            {
                var moviePeople = await _repository.MoviePerson.GetAllMoviePeopleAsync();

                _logger.LogInfo($"Returned all moviePeople from database.");

                var moviePeopleResult = _mapper.Map<IEnumerable<MoviePersonDto>>(moviePeople);

                return Ok(moviePeopleResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMoviePeople action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMoviePersonById(int id)
        {
            try
            {
                var moviePerson = await _repository.MoviePerson.GetMoviePersonByIdAsync(id);
                if (moviePerson is null)
                {
                    _logger.LogError($"MoviePerson with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned moviePerson with id: {id}");
                    var moviePersonResult = _mapper.Map<MoviePersonDto>(moviePerson);
                    return Ok(moviePersonResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMoviePersonById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMoviePerson([FromBody] MoviePersonForCreationDto moviePerson)
        {
            try
            {
                if (moviePerson is null)
                {
                    _logger.LogError("MoviePerson object sent from client is null.");
                    return BadRequest("MoviePerson object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid moviePerson object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var moviePersonEntity = _mapper.Map<MoviePerson>(moviePerson);
                _repository.MoviePerson.CreateMoviePerson(moviePersonEntity);
                await _repository.SaveAsync();
                var createdMoviePerson = _mapper.Map<MoviePersonDto>(moviePersonEntity);
                return CreatedAtRoute("MoviePersonByIdAsync", new { id = createdMoviePerson.ID }, createdMoviePerson);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMoviePerson action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMoviePerson(int id, [FromBody] MoviePersonForUpdateDto moviePerson)
        {
            try
            {
                if (moviePerson is null)
                {
                    _logger.LogError("MoviePerson object sent from client is null.");
                    return BadRequest("MoviePerson object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid moviePerson object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var moviePersonEntity = await _repository.MoviePerson.GetMoviePersonByIdAsync(id);
                if (moviePersonEntity is null)
                {
                    _logger.LogError($"MoviePerson with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(moviePerson, moviePersonEntity);
                _repository.MoviePerson.UpdateMoviePerson(moviePersonEntity);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateMoviePerson action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoviePerson(int id)
        {
            try
            {
                var moviePerson = await _repository.MoviePerson.GetMoviePersonByIdAsync(id);
                if (moviePerson == null)
                {
                    _logger.LogError($"MoviePerson with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.MoviePerson.DeleteMoviePerson(moviePerson);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteMoviePerson action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
