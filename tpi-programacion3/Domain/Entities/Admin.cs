using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Admin : User
    {
        public Admin()
        {
            UserType = "admin";

        }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<User> Users { get; set; } = new List<User>();


    }
}
