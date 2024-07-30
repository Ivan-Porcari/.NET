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
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ICollection<Purchased> GetCustomerPurchaseds(int customerId) =>
            _context.Customers.Include(a => a.PurchasedsAttended).ThenInclude(p => p.Products).Where(c => c.Id == customerId)
            .Select(a => a.PurchasedsAttended).FirstOrDefault() ?? new List<Purchased>();

    }
} 
