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
        public IActionResult GetAllMoviePeople()
        {
            try
            {
                var moviePeople = _repository.MoviePerson.GetAllMoviePeople();

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
        public IActionResult GetMoviePersonById(int id)
        {
            try
            {
                var moviePerson = _repository.MoviePerson.GetMoviePersonById(id);
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
        public IActionResult CreateMoviePerson([FromBody] MoviePersonForCreationDto moviePerson)
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
                _repository.Save();
                var createdMoviePerson = _mapper.Map<MoviePersonDto>(moviePersonEntity);
                return CreatedAtRoute("MoviePersonById", new { id = createdMoviePerson.ID }, createdMoviePerson);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMoviePerson action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMoviePerson(int id, [FromBody] MoviePersonForUpdateDto moviePerson)
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
                var moviePersonEntity = _repository.MoviePerson.GetMoviePersonById(id);
                if (moviePersonEntity is null)
                {
                    _logger.LogError($"MoviePerson with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(moviePerson, moviePersonEntity);
                _repository.MoviePerson.UpdateMoviePerson(moviePersonEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateMoviePerson action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMoviePerson(int id)
        {
            try
            {
                var moviePerson = _repository.MoviePerson.GetMoviePersonById(id);
                if (moviePerson == null)
                {
                    _logger.LogError($"MoviePerson with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.MoviePerson.DeleteMoviePerson(moviePerson);
                _repository.Save();
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
