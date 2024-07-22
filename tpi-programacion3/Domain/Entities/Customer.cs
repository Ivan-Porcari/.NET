using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : User // hereda de user 
    {
        public ICollection<Purchased> Purchased { get; set; } = new List<Purchased>();
        //public List<string> Cart { get; set; }
        //public List<string> Purchased { get; set; }
    }
}
