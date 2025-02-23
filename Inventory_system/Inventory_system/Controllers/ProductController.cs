using Inventory_system.Dtos;
using Inventory_system.Models;
using Inventory_system.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_system.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
            //logging - to track errors and events
        }   


        //Create new product with variants and sub-variants
        //returns 200 Ok if successful
        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct([FromBody] ProductDto product)
        {
            try
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.CreateProduct(product);
            return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request.{ex.Message}");
            }
        }

        //To add stock quantity (purchase)
        [HttpPost("AddStock")]
        public IActionResult AddStock(StockRequestDto AddStock)
        {
            try
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.AddStock(AddStock);
            return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request.{ex.Message}");
            }
        }

        //To remove or decrease stock quantity (sales)
        [HttpPost("RemoveStock")]
        public IActionResult RemoveStock([FromBody] StockRequestDto RemoveStock)
        {
            try
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.RemoveStock(RemoveStock);
            return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request.{ex.Message}");
            }
        }

        //To list available products with variants and sub-variants
        [HttpGet("Products")]
        public IActionResult ListProducts()
        {
            try
            {
            var products = _service.ListProducts();
            return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request.{ex.Message}");
            }
        }
    }
}
