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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //ID numerico
        public int Id { get; set; }
        public string Title { get; set; }
        public string Band { get; set; }
        public string PhotoURL { get; set; }
        public string  Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
