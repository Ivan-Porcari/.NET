using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class PurchasedDto
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        public static PurchasedDto Create(Purchased purchased)
        {
            return new PurchasedDto
            {
                Id = purchased.Id,
                PurchaseDate = purchased.PurchaseDate,
                CustomerId = purchased.CustomerId,
                Customer = purchased.Customer != null ? CustomerDto.Create(purchased.Customer) : null
            };
        }

        public static List<PurchasedDto> CreateList(IEnumerable<Purchased> purchases)
        {
            return purchases.Select(p => Create(p)).ToList();
        }
    }
}
}
