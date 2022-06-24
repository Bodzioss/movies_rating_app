using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects.EpisodeDtos;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MoviesRatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public EpisodesController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Episodes
        [HttpGet]
        public async Task<IActionResult> GetAllEpisodes()
        {
            try
            {
                var episodes = await _repository.Episode.GetAllEpisodesAsync();

                _logger.LogInfo($"Returned all owners from database.");

                var episodesResult = _mapper.Map<IEnumerable<EpisodeDto>>(episodes);

                return Ok(episodesResult);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEpisodesAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEpisodeById(int id)
        {
            try
            {
                var episode = await _repository.Episode.GetEpisodeByIdAsync(id);
                if (episode is null)
                {
                    _logger.LogError($"Episode with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned episode with id: {id}");
                    var episodeResult = _mapper.Map<EpisodeDto>(episode);
                    return Ok(episodeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEpisodeByIdAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEpisode([FromBody] EpisodeForCreationDto episode)
        {
            try
            {
                if (episode is null)
                {
                    _logger.LogError("Episode object sent from client is null.");
                    return BadRequest("Episode object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid episode object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var episodeEntity = _mapper.Map<Episode>(episode);
                _repository.Episode.CreateEpisode(episodeEntity);
                await _repository.SaveAsync();
                var createdEpisode = _mapper.Map<EpisodeDto>(episodeEntity);
                return CreatedAtRoute("EpisodeById", new { id = createdEpisode.ID }, createdEpisode);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateEpisode action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEpisode(int id, [FromBody] EpisodeForUpdateDto episode)
        {
            try
            {
                if (episode is null)
                {
                    _logger.LogError("Episode object sent from client is null.");
                    return BadRequest("Episode object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid episode object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var episodeEntity = await _repository.Episode.GetEpisodeByIdAsync(id);
                if (episodeEntity is null)
                {
                    _logger.LogError($"Episode with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(episode, episodeEntity);
                _repository.Episode.UpdateEpisode(episodeEntity);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateEpisode action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpisode(int id)
        {
            try
            {
                var episode =await _repository.Episode.GetEpisodeByIdAsync(id);
                if (episode == null)
                {
                    _logger.LogError($"Episode with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.Episode.DeleteEpisode(episode);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteEpisode action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
