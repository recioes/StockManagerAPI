using Microsoft.AspNetCore.Mvc;
using StockAPI.Core.DTOs;
using StockAPI.Core.Interfaces.Services;
using StockAPI.Core.Models;
using StockAPI.Core.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace StockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ApiController
    {

            private readonly IStoreService _storeService;

            public StoreController(IStoreService storeService)
            {
            _storeService = storeService;
            }


            [HttpPost]
            //[Authorize]
            [SwaggerOperation(Summary = "Creates a new store")]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<IActionResult> AddAsync([FromBody] StoreDto store)
            {
                if (!ModelState.IsValid)
                {
                    return ValidateAndResponse();
            }

                await _storeService.AddAsync(store);
                return Ok();
            }

            [HttpGet("{id}")]
            // [AllowAnonymous]
            [SwaggerOperation(Summary = "Gets a store by its Id")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<StoreModel>> SearchByIdAsync(int id)
            {
                var stores = await _storeService.SearchByIdAsync(id);
                return Ok(stores);
            }


            [HttpDelete("{id}")]
            //[Authorize]
            [SwaggerOperation(Summary = "Deletes an existing store")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> DeleteAsync([FromRoute] int id)
            {
                await _storeService.DeleteAsync(id);
                return NoContent();

            }

            [HttpGet]
            // [AllowAnonymous]
            [SwaggerOperation(Summary = "Gets all stores")]
            [ProducesResponseType(StatusCodes.Status200OK)]

            public async Task<ActionResult<IEnumerable<StoreModel>>> SearchAllAsync([FromQuery] int page = 1, int pageSize = 10, string sortField = "name", string sortDirection = "ASC")
            {
                var stores = await _storeService.SearchAllAsync(page, pageSize, sortField, sortDirection);
                return Ok(stores);
            }

            [HttpPut("{id}")]
            // [Authorize]
            [SwaggerOperation(Summary = "Updates an existing store")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<IActionResult> UpdateAsync(int id, [FromBody] StoreDto store)
            {
                if (!ModelState.IsValid)
                {
                    return ValidateAndResponse();
                }

                await _storeService.UpdateAsync(id, store);
                return Ok();
            }

        }
    }
