using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class ProductController : ApiController
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        //[Authorize]
        [SwaggerOperation(Summary = "Creates a new product")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromBody] ProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return ValidateAndResponse();
            }

            await _productService.AddAsync(product);
            return Ok();
        }
        
        [HttpGet("{id}")]
       // [AllowAnonymous]
        [SwaggerOperation(Summary = "Gets a product by its Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductModel>> SearchByIdAsync(int id)
        {
           var products = await _productService.SearchByIdAsync(id);
            return Ok(products);
        }


        [HttpDelete("{id}")]
        //[Authorize]
        [SwaggerOperation(Summary = "Deletes an existing product")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();

        }

        [HttpGet]
       // [AllowAnonymous]
        [SwaggerOperation(Summary = "Gets all products")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<ProductModel>>> SearchAllAsync([FromQuery] int page = 1, int pageSize = 10, string sortField = "name", string sortDirection = "ASC")
        {
            var products = await _productService.SearchAllAsync(page, pageSize, sortField, sortDirection);
            return Ok(products);
        }

        [HttpPut("{id}")]
        // [Authorize]
        [SwaggerOperation(Summary = "Updates an existing product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return ValidateAndResponse();
            }

            await _productService.UpdateAsync(id, product);
            return Ok();
        }
        








    }
}
