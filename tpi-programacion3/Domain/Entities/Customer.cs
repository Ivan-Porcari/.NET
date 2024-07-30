﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Domain.Entities
{
    public class Customer : User // hereda de user 
    {
        public Customer()
        {
            UserType = "customer";
        }
        public ICollection<Purchased> PurchasedsAttended { get; set; } = new List<Purchased>();

    }
}
