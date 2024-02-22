using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockAPI.Core.DTOs;
using StockAPI.Core.Interfaces.Services;
using StockAPI.Core.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace StockAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ApiController
    {

        private readonly IStockItemService _stockItemService;

        public StockController(IStockItemService stockItemService)
        {
            _stockItemService = stockItemService;
        }

        [HttpPost]
        //[Authorize]
        [SwaggerOperation(Summary = "Creates a stock entry for a specific item")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateStockAsync([FromBody] StockItemDto stockItem)
        {
            if (!ModelState.IsValid)
            {
                return ValidateAndResponse();
            }

            await _stockItemService.CreateStockAsync(stockItem);
            return Ok();
        }


        [HttpPut("{id}/increase")]
       // [Authorize]
        [SwaggerOperation(Summary = "Increases stock quantity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMoreToStockAsync(int id, [FromBody] StockItemDto stockItem)
        {
            if (!ModelState.IsValid)
            {
                return ValidateAndResponse();
            }

            await _stockItemService.AddMoreToStockAsync(id, stockItem);
            return Ok();
        }


        [HttpPut("{id}/decrease")]
        // [Authorize]
        [SwaggerOperation(Summary = "Lowers stock quantity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LowerStockQuantityAsync(int id, [FromBody] StockItemDto stockItem)
        {
            if (!ModelState.IsValid)
            {
                return ValidateAndResponse();
            }

            await _stockItemService.LowerStockQuantityAsync(id, stockItem);
            return Ok();
        }


        [HttpDelete("{id}")]
        //[Authorize]
        [SwaggerOperation(Summary = "Deletes the entire stock of a product")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStockAsync([FromRoute] int id)
        {
            await _stockItemService.DeleteStockAsync(id);
            return NoContent();
        }

    }


}
