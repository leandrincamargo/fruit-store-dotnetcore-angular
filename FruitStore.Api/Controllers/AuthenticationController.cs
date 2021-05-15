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
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Authenticate([FromBody] UserLoginDto dto)
        {
            try
            {
                var validRes = new UserLoginDtoValidation().Validate(dto);
                if (!validRes.IsValid)
                    return BadRequest(validRes.Errors);

                var token = _authenticationService.Authenticate(dto, out string error);

                if (!string.IsNullOrWhiteSpace(error))
                    return NotFound(new { message = error });

                return Ok(new { token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
