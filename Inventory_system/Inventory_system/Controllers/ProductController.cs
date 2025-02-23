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
        }   


        //To add a new product with variants and sub-variants
        [Route("CreateProduct")]
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDto product)
        {
            _service.CreateProduct(product);
            return Ok();
        }

        //To add stock quantity (purchase)
        [Route("AddStock")]
        [HttpPost]
        public IActionResult AddStock(StockRequestDto AddStock)
        {
            _service.AddStock(AddStock);
            return Ok();
        }

        //To remove or decrease stock quantity (sales)
        [Route("RemoveStock")]
        [HttpPost]
        public IActionResult RemoveStock([FromBody] StockRequestDto RemoveStock)
        {
            _service.RemoveStock(RemoveStock);
            return Ok();
        }

        //To list available products with variants and sub-variants
        [Route("Products")]
        [HttpGet]
        public IActionResult ListProducts()
        {
            var products = _service.ListProducts();
            return Ok(products);
        }
    }
}
