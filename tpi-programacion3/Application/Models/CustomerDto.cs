using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }

        public static CustomerDto Create(Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                LastName = customer.LastName,
                Password = customer.Password,
                Email = customer.Email,
                UserName = customer.UserName,
                UserType = customer.UserType
            };
        }

        public static List<CustomerDto> CreateList(IEnumerable<Customer> customers)
        {
            return customers.Select(c => Create(c)).ToList();
        }
    }
}
