using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TicketDocService : ITicketDocService
    {
        private readonly ITicketDocRepository _ticketDocRepository;
        private readonly IUserRepository _userRepository;
        public TicketDocService(ITicketDocRepository ticketDocRepository, IUserRepository userRepository)
        {
            _ticketDocRepository = ticketDocRepository;
            _userRepository = userRepository;
        }

        public string GetTicketDocDetails(TicketDoc ticketBill)
        {
            var ticketDocDetails = $"Detalles de la Compra (ID: {ticketBill.IdOrden})\n";
            ticketDocDetails += $"Cliente: {ticketBill.CustomertName}\n";
            ticketDocDetails += $"Productos: \n";

            foreach (var product in ticketBill.Purchased.Products)
            {
                ticketDocDetails += $"{product.Title} - Precio: {product.Price:C} - Descuento: {product.Discount: %}\n";
            }

            ticketDocDetails += $"Subtotal: {ticketBill.Purchased.SubTotal: $}\n";
            ticketDocDetails += $"Impuestos: {ticketBill.Purchased.Tax: $}\n";
            ticketDocDetails += $"Total: {ticketBill.Total:C}";

            return ticketDocDetails;

        }
    }
}
