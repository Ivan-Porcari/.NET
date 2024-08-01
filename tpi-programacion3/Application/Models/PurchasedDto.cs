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
        public Guid IdPurchased { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CustomerId { get; set; }
        public UserDto Customer { get; set; } = new UserDto(); // Inicializado
        public List<string> Products { get; set; } = new List<string>(); // Inicializado
        public double SubTotal { get; set; }

        public static PurchasedDto Create(Purchased purchased)
        {
            return new PurchasedDto
            {
                IdPurchased = purchased.IdPurchased,
                PurchaseDate = purchased.PurchaseDate,
                CustomerId = purchased.CustomerId,
                Products = purchased.Products.Select(p => p.Title).ToList(),
                SubTotal = purchased.SubTotal,
                Customer = new UserDto
                {
                    Name = purchased.CustomerName, // Accediendo a las propiedades correctas
                    Email = purchased.CustomerEmail
                }
            };
        }

        public static List<PurchasedDto> CreateList(IEnumerable<Purchased> purchases)
        {
            return purchases.Select(Create).ToList();
        }

    }
}
