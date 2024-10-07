using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDiscoManiacos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasedController : ControllerBase
    {
        private readonly IPurchasedService _purchasedService;

        public PurchasedController(IPurchasedService purchasedService)
        {
            _purchasedService = purchasedService;
        }

        [HttpGet("GetPurchased/{customerName}")]
        public ActionResult<Purchased> GetPurchased(string customerName)
        {
            var purchased = _purchasedService.GetPurchasedByCustomerName(customerName); ;
            if (purchased == null)
            {
                return NotFound();
            }
            return Ok(purchased);
        }

        [HttpPost("AddProductToCart/{customerName}/{customerId}")]
        public ActionResult AddProductToCart(string customerName, Guid productId)
        {
            var success = _purchasedService.AddProductToCart(customerName, productId);
            if (!success)
            {
                return NotFound("Producto o carrito de compras no encontrado");
            }
            return Ok("Producto agregado al carrito exitosamente");
        }

        [HttpPost("RemoveProductFromCart/{customerName}/{productId}")]
        public ActionResult RemoveProductFromCart(string customerName, Guid productId)
        {
            var success = _purchasedService.RemoveProductFromCart(customerName, productId);
            if (!success)
            {
                return NotFound("Producto o carrito de compras no encontrado");
            }
            return Ok("Producto removido del carrito exitosamente");
        }
    }
}
