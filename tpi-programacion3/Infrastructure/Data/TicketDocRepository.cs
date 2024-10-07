using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TicketDocRepository : EfRepository<TicketDoc>, ITicketDocRepository
    {
        public TicketDocRepository(ApplicationDbContext context) : base(context)
        {
        }

        public TicketDoc GetTicketDocById(Guid ticketBillId)
        {
            return _context.TicketDocs
                .Include(td => td.Purchased)
                .ThenInclude(p => p.Products)
                .FirstOrDefault(td => td.IdOrden == ticketBillId);
        }

        public bool CreateTicketBill(TicketDoc ticketDoc)
        {
            try
            {
                _context.TicketDocs.Add(ticketDoc);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTicketBill(TicketDoc ticketDoc)
        {
            if (_context.TicketDocs.Any(td => td.IdOrden == ticketDoc.IdOrden))
            {
                _context.TicketDocs.Update(ticketDoc);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteTicketBill(Guid ticketBillId)
        {
            var ticketBillToDelete = _context.TicketDocs.FirstOrDefault(td => td.IdOrden == ticketBillId);
            if (ticketBillToDelete != null)
            {
                _context.TicketDocs.Remove(ticketBillToDelete);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
