using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects.MovieGenreDtos;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MoviesRatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenresController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public MovieGenresController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/MovieGenres
        [HttpGet]
        public async Task<IActionResult> GetAllMovieGenres()
        {
            try
            {
                var movieGenres = await _repository.MovieGenre.GetAllMovieGenresAsync();

                _logger.LogInfo($"Returned all movieGenres from database.");

                var movieGenresResult = _mapper.Map<IEnumerable<MovieGenreDto>>(movieGenres);

                return Ok(movieGenresResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMovieGenres action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieGenreById(int id)
        {
            try
            {
                var movieGenre = await _repository.MovieGenre.GetMovieGenreByIdAsync(id);
                if (movieGenre is null)
                {
                    _logger.LogError($"MovieGenre with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned movieGenre with id: {id}");
                    var movieGenreResult = _mapper.Map<MovieGenreDto>(movieGenre);
                    return Ok(movieGenreResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMovieGenreById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovieGenre([FromBody] MovieGenreForCreationDto movieGenre)
        {
            try
            {
                if (movieGenre is null)
                {
                    _logger.LogError("MovieGenre object sent from client is null.");
                    return BadRequest("MovieGenre object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid movieGenre object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var movieGenreEntity = _mapper.Map<MovieGenre>(movieGenre);
                _repository.MovieGenre.CreateMovieGenre(movieGenreEntity);
                await _repository.SaveAsync();
                var createdMovieGenre = _mapper.Map<MovieGenreDto>(movieGenreEntity);
                return CreatedAtRoute("MovieGenreById", new { id = createdMovieGenre.ID }, createdMovieGenre);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMovieGenre action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovieGenre(int id, [FromBody] MovieGenreForUpdateDto movieGenre)
        {
            try
            {
                if (movieGenre is null)
                {
                    _logger.LogError("MovieGenre object sent from client is null.");
                    return BadRequest("MovieGenre object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid movieGenre object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var movieGenreEntity = await _repository.MovieGenre.GetMovieGenreByIdAsync(id);
                if (movieGenreEntity is null)
                {
                    _logger.LogError($"MovieGenre with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(movieGenre, movieGenreEntity);
                _repository.MovieGenre.UpdateMovieGenre(movieGenreEntity);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateMovieGenre action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieGenre(int id)
        {
            try
            {
                var movieGenre = await _repository.MovieGenre.GetMovieGenreByIdAsync(id);
                if (movieGenre == null)
                {
                    _logger.LogError($"MovieGenre with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.MovieGenre.DeleteMovieGenre(movieGenre);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteMovieGenre action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
