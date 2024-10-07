using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDiscoManiacos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketDocController : ControllerBase
    {
        private readonly ITicketDocService _ticketDocService;

        public TicketDocController(ITicketDocService ticketDocService)
        {
            _ticketDocService = ticketDocService;
        }

        [HttpGet("GetInvoiceDetails/{ticketBillId}")]
        public IActionResult GetTicketDocDetails(TicketDoc ticketBillId)
        {
            var ticket = _ticketDocService.GetTicketDocDetails(ticketBillId);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }
    }
}
