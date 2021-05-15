using FruitStore.Application.Interfaces.Services;
using FruitStore.Application.Validations;
using FruitStore.Domain.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FruitStore.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Add([FromBody] NewUserDto dto)
        {
            try
            {
                var validRes = new NewUserDtoValidation().Validate(dto);
                if (!validRes.IsValid)
                    return BadRequest(validRes.Errors);

                _userService.Add(dto);
                return Created("", null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(Guid id, [FromBody] EditUserDto dto)
        {
            try
            {
                var validRes = new EditUserDtoValidation().Validate(dto);
                if (!validRes.IsValid)
                    return BadRequest(validRes.Errors);
                if (_userService.GetById(id) == null)
                    return BadRequest("Usuário não encontrado");

                _userService.Update(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Authorize]
        [Route("{id}/Deactivate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Deactivate(Guid id)
        {
            try
            {
                if (_userService.GetById(id) == null)
                    return BadRequest("Usuário não encontrado");

                _userService.ChangeStatus(id, false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Authorize]
        [Route("{id}/Activate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Activate(Guid id)
        {
            try
            {
                if (_userService.GetById(id) == null)
                    return BadRequest("Usuário não encontrado");

                _userService.ChangeStatus(id, true);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "41361f47-53bf-4084-965f-cabc95532565")]
        [Route("GetNonActiveCommonUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNonActiveCommonUsers(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var usersPagination = _userService.GetNonActiveCommonUsers(pageNumber, pageSize);
                return Ok(usersPagination);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
