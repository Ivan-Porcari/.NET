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

        public Purchased GetPurchasedByCustomerName(string customerName)
        {
            var purchased = _context.Purchaseds.FirstOrDefault(ps => ps.CustomerName == customerName);
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

            _context.SaveChanges();
            return true;
        }

        public bool RemoveProductFromCart(string customerName, Guid productId)
        {
            var purchased = GetPurchasedByCustomerName(customerName);
            if (purchased == null || !purchased.Products.Any(p => p.Id == productId))
            {
                return false;
            }

            var product = purchased.Products.First(p => p.Id == productId);
            purchased.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Purchased> GetAllPurchases()
        {
            return _context.Purchaseds.ToList();
        }

    }
}
