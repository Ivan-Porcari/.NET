using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Purchased
    {
        [Key]
        public Guid IdPurchased { get; set; } 
        public DateTime PurchaseDate { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } // Propiedad de navegación
        public string CustomerName => Customer?.Name; // Propiedad calculada
        public string CustomerEmail => Customer?.Email; // Propiedad calculada
        public double SubTotal => CalcularSubtotal();
        public List<Product> Products { get; set; }
        public Purchased()
        {
            IdPurchased = Guid.NewGuid();
            Products = new List<Product>();
        }

        public double CalcularSubtotal()
        {
            double total = 0;
            foreach (var product in Products)
            {
                total += product.Price;
            }
            return total;
        }


    }
}
