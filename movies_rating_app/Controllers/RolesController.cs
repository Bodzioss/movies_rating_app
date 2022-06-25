using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities;
using Entities.DataTransferObjects.RoleDtos;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RolesRatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public RolesController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = await _repository.Role.GetAllRolesAsync();

                _logger.LogInfo($"Returned all roles from database.");

                var rolesResult = _mapper.Map<IEnumerable<RoleDto>>(roles);

                return Ok(rolesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRoles action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("{id}", Name = "RoleById")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            try
            {
                var role = await _repository.Role.GetRoleByIdAsync(id);
                if (role is null)
                {
                    _logger.LogError($"Role with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned role with id: {id}");
                    var roleResult = _mapper.Map<RoleDto>(role);
                    return Ok(roleResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRoleById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleForCreationDto role)
        {
            try
            {
                if (role is null)
                {
                    _logger.LogError("Role object sent from client is null.");
                    return BadRequest("Role object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid role object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var roleEntity = _mapper.Map<Role>(role);
                _repository.Role.CreateRole(roleEntity);
                await _repository.SaveAsync();
                var createdRole = _mapper.Map<RoleDto>(roleEntity);
                return CreatedAtRoute("RoleById", new { id = createdRole.ID }, createdRole);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateRole action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleForUpdateDto role)
        {
            try
            {
                if (role is null)
                {
                    _logger.LogError("Role object sent from client is null.");
                    return BadRequest("Role object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid role object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var roleEntity = await _repository.Role.GetRoleByIdAsync(id);
                if (roleEntity is null)
                {
                    _logger.LogError($"Role with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(role, roleEntity);
                _repository.Role.UpdateRole(roleEntity);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateRole action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var role = await _repository.Role.GetRoleByIdAsync(id);
                if (role == null)
                {
                    _logger.LogError($"Role with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.Role.DeleteRole(role);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteRole action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
