using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects.SeriesDtos;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SeriesRatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public SeriesController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Series
        [HttpGet]
        public IActionResult GetAllSeries()
        {
            try
            {
                var series = _repository.Series.GetAllSeries();

                _logger.LogInfo($"Returned all series from database.");

                var seriesResult = _mapper.Map<IEnumerable<SeriesDto>>(series);

                return Ok(seriesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSeries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetSeriesById(int id)
        {
            try
            {
                var series = _repository.Series.GetSeriesById(id);
                if (series is null)
                {
                    _logger.LogError($"Series with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned series with id: {id}");
                    var seriesResult = _mapper.Map<SeriesDto>(series);
                    return Ok(seriesResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSeriesById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSeries([FromBody] SeriesForCreationDto series)
        {
            try
            {
                if (series is null)
                {
                    _logger.LogError("Series object sent from client is null.");
                    return BadRequest("Series object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid series object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var seriesEntity = _mapper.Map<Series>(series);
                _repository.Series.CreateSeries(seriesEntity);
                _repository.Save();
                var createdSeries = _mapper.Map<SeriesDto>(seriesEntity);
                return CreatedAtRoute("SeriesById", new { id = createdSeries.ID }, createdSeries);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSeries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSeries(int id, [FromBody] SeriesForUpdateDto series)
        {
            try
            {
                if (series is null)
                {
                    _logger.LogError("Series object sent from client is null.");
                    return BadRequest("Series object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid series object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var seriesEntity = _repository.Series.GetSeriesById(id);
                if (seriesEntity is null)
                {
                    _logger.LogError($"Series with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(series, seriesEntity);
                _repository.Series.UpdateSeries(seriesEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSeries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeries(int id)
        {
            try
            {
                var series = _repository.Series.GetSeriesById(id);
                if (series == null)
                {
                    _logger.LogError($"Series with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.Series.DeleteSeries(series);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSeries action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
