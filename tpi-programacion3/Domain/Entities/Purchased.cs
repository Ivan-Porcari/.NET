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
        public double Tax { get; set; } = 0.21;
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<Product> Products { get; set; }
        public double SubTotal => CalcularSubtotal();

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
