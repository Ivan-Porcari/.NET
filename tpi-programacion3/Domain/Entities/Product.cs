
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [Key] //atributo de identificación de todos los registros
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Band { get; set; } = string.Empty;
        public string PhotoURL { get; set; } = string.Empty;
        public string  Category { get; set; } = string.Empty;
        public double Price { get; set; }
        public double Discount { get; set; } = 0;
        public int? Stock { get; set; }
        public bool Activo { get; set; }
        public List<Purchased> Purchaseds { get; set; }

        public Product()
        {
            Purchaseds = new List<Purchased>();
        }
    }
}
