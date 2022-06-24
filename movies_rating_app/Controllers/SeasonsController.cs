using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects.SeasonDtos;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SeasonsRatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public SeasonsController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Seasons
        [HttpGet]
        public async Task<IActionResult> GetAllSeasons()
        {
            try
            {
                var seasons = await _repository.Season.GetAllSeasonsAsync();

                _logger.LogInfo($"Returned all seasons from database.");

                var seasonsResult = _mapper.Map<IEnumerable<SeasonDto>>(seasons);

                return Ok(seasonsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSeasons action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeasonById(int id)
        {
            try
            {
                var season = await _repository.Season.GetSeasonByIdAsync(id);
                if (season is null)
                {
                    _logger.LogError($"Season with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned season with id: {id}");
                    var seasonResult = _mapper.Map<SeasonDto>(season);
                    return Ok(seasonResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSeasonById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeason([FromBody] SeasonForCreationDto season)
        {
            try
            {
                if (season is null)
                {
                    _logger.LogError("Season object sent from client is null.");
                    return BadRequest("Season object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid season object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var seasonEntity = _mapper.Map<Season>(season);
                _repository.Season.CreateSeason(seasonEntity);
                await _repository.SaveAsync();
                var createdSeason = _mapper.Map<SeasonDto>(seasonEntity);
                return CreatedAtRoute("SeasonByIdAsync", new { id = createdSeason.ID }, createdSeason);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSeason action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeason(int id, [FromBody] SeasonForUpdateDto season)
        {
            try
            {
                if (season is null)
                {
                    _logger.LogError("Season object sent from client is null.");
                    return BadRequest("Season object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid season object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var seasonEntity = await _repository.Season.GetSeasonByIdAsync(id);
                if (seasonEntity is null)
                {
                    _logger.LogError($"Season with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(season, seasonEntity);
                _repository.Season.UpdateSeason(seasonEntity);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSeason action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeason(int id)
        {
            try
            {
                var season = await _repository.Season.GetSeasonByIdAsync(id);
                if (season == null)
                {
                    _logger.LogError($"Season with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.Season.DeleteSeason(season);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSeason action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
