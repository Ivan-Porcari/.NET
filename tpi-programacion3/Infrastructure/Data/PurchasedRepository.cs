using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PurchasedRepository : EfRepository<Purchased>, IPurchasedRepository
    {
        public PurchasedRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Purchased GetPurchasedByCustomerId(int customerId)
        {
            var purchased = _context.Purchaseds.FirstOrDefault(ps => ps.CustomerId == customerId);
            return purchased ?? new Purchased();
        }
        public bool UpdatePurchased(Purchased purchased)
        {
            var prevPurchased = _context.Purchaseds.FirstOrDefault(ps => ps.IdPurchased == purchased.IdPurchased);

            if (prevPurchased == null)
            {
                return false;
            }

            prevPurchased.Products = purchased.Products;
            prevPurchased.Tax = purchased.Tax;

            _context.SaveChanges();
            return true;
        }


    }
}
