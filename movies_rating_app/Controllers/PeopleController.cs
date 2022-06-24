using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects.PersonDtos;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PeopleRatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public PeopleController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/People
        [HttpGet]
        public IActionResult GetAllPeople()
        {
            try
            {
                var persons = _repository.Person.GetAllPeople();

                _logger.LogInfo($"Returned all persons from database.");

                var personsResult = _mapper.Map<IEnumerable<PersonDto>>(persons);

                return Ok(personsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPeople action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            try
            {
                var person = _repository.Person.GetPersonById(id);
                if (person is null)
                {
                    _logger.LogError($"Person with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned person with id: {id}");
                    var personResult = _mapper.Map<PersonDto>(person);
                    return Ok(personResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPersonById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] PersonForCreationDto person)
        {
            try
            {
                if (person is null)
                {
                    _logger.LogError("Person object sent from client is null.");
                    return BadRequest("Person object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid person object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var personEntity = _mapper.Map<Person>(person);
                _repository.Person.CreatePerson(personEntity);
                _repository.Save();
                var createdPerson = _mapper.Map<PersonDto>(personEntity);
                return CreatedAtRoute("PersonById", new { id = createdPerson.ID }, createdPerson);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePerson action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] PersonForUpdateDto person)
        {
            try
            {
                if (person is null)
                {
                    _logger.LogError("Person object sent from client is null.");
                    return BadRequest("Person object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid person object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var personEntity = _repository.Person.GetPersonById(id);
                if (personEntity is null)
                {
                    _logger.LogError($"Person with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(person, personEntity);
                _repository.Person.UpdatePerson(personEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdatePerson action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            try
            {
                var person = _repository.Person.GetPersonById(id);
                if (person == null)
                {
                    _logger.LogError($"Person with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.Person.DeletePerson(person);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeletePerson action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
