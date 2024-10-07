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
        public double Tax { get; set; }
        public int CustomerId { get; set; }
        public UserDto Customer { get; set; } 
        public List<string> Products { get; set; } 
        public double SubTotal { get; set; }

    }
}
