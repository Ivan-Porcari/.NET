using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDiscoManiacos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("GetProductList")]
        public ActionResult<IEnumerable<Product?>> GetProductList()
        {
            var productList = _productService.GetProductList();
            return Ok(productList);
        }

        [HttpGet("GetProductById/{id}")]
        public ActionResult<Product?> GetById(Guid id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("CreateProduct")]
        public ActionResult CreateProduct(Product product)
        {
            var success = _productService.CreateProduct(product);
            if (!success)
            {
                return Conflict("Ya existe un producto con el mismo ID");
            }
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("UpdateProduct/{id}")]
        public ActionResult UpdateProduct(Guid id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("ID de producto no valido");
            }
            var success = _productService.UpdateProduct(product);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("DeleteProduct/{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            var success = _productService.DeleteProduct(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("ApplyDiscount/{id}")]
        public ActionResult ApplyDiscount(Guid id, double percentage)
        {
            var success = _productService.ApplyDiscount(id, percentage);
            if (!success)
            {
                return NotFound();
            }
            return Ok("El descuento se aplico correctamente");
        }
    }
}
