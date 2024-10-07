using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TicketDoc
    {
        [Key]
        public Guid IdOrden { get; set; }
        public string CustomertName { get; set; }
        public Purchased Purchased { get; set; }
        public double Total => CalculateTotal();
        public string Estado { get; set; }

        public int CustomerId { get; set; }
        public TicketDoc()
        {
            IdOrden = Guid.NewGuid();
            Purchased = new Purchased();
            Estado = "pendiente";
        }

        private double CalculateTotal()
        {
            double discountTotal = 0;
            foreach (var product in Purchased.Products)
            {
                discountTotal += product.Price * product.Discount;
            }

            return Purchased.SubTotal - discountTotal + (Purchased.SubTotal * Purchased.Tax);
        }
    }
}
