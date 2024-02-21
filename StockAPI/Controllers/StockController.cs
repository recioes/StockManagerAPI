using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CreateStockAsync([FromBody] StockItemModel stockItem)
        {
            if (!ModelState.IsValid)
            {
                return ValidateAndResponse();
            }

            await _stockItemService.CreateStockAsync(stockItem);
            return Ok();
        }


        [HttpPut("{id}")]
       // [Authorize]
        [SwaggerOperation(Summary = "Updates an existing stock item")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStockAsync([FromBody] StockItemModel stockItem)
        {
            if (!ModelState.IsValid)
            {
                return ValidateAndResponse();
            }

            await _stockItemService.UpdateStockAsync(stockItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        //[Authorize]
        [SwaggerOperation(Summary = "Deletes an existing stock for an specific item")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFromStockAsync([FromRoute] int id)
        {
            await _stockItemService.DeleteFromStockAsync(id);
            return NoContent();
        }

    }


}
