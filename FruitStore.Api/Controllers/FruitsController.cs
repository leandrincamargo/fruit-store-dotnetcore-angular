using FruitStore.Application.Interfaces.Services;
using FruitStore.Application.Validations;
using FruitStore.Domain.DTOs;
using FruitStore.Domain.Entities;
using FruitStore.Domain.Enums;
using FruitStore.Domain.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FruitStore.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private readonly IFruitService _fruitService;

        public FruitsController(IFruitService debtService)
        {
            _fruitService = debtService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pagination<Fruit>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var debts = _fruitService.Get(pageNumber, pageSize);
                return Ok(debts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] FruitDto dto)
        {
            try
            {
                var validRes = new FruitDtoValidation().Validate(dto);
                if (!validRes.IsValid)
                    return BadRequest(validRes.Errors);

                var id = _fruitService.Add(dto);
                return Created($"Game: {id}", id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(Guid id, [FromBody] FruitDto dto)
        {
            try
            {
                var validRes = new FruitDtoValidation().Validate(dto);
                if (!validRes.IsValid)
                    return BadRequest(validRes.Errors);
                if (_fruitService.GetById(id) == null)
                    return BadRequest("Fruta não encontrado");

                _fruitService.Update(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id}/AddToCart")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddToCart(Guid id)
        {
            try
            {
                var fruit = _fruitService.GetById(id);
                if (fruit == null)
                    return BadRequest("Fruta não encontrado");
                if (fruit.StockAmount <= 0)
                    return BadRequest("Fruta sem estoque");

                _fruitService.ChangeAmount(id, (int)OperationEnum.Minus, 1);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id}/RemoveFromCart")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RemoveFromCart(Guid id)
        {
            try
            {
                if (_fruitService.GetById(id) == null)
                    return BadRequest("Fruta não encontrado");

                _fruitService.ChangeAmount(id, (int)OperationEnum.Plus, 1);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id}/AddItemsToAmount")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateAmount(Guid id, int count)
        {
            try
            {
                if (_fruitService.GetById(id) == null)
                    return BadRequest("Fruta não encontrado");

                _fruitService.ChangeAmount(id, (int)OperationEnum.Plus, count);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                if (_fruitService.GetById(id) == null)
                    return BadRequest("Fruta não encontrado");

                _fruitService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
