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
        public string Email { get; set; }
        public string Password {  get; set; }
        public string UserType { get; set; }


        public IList<PurchasedDto> PurchasedsAttended { get; set; } = new List<PurchasedDto>();
        
        public static CustomerDto Create(Customer customer)
        {

            var dto = new CustomerDto();
            dto.Id = customer.Id;
            dto.Name = customer.Name;
            dto.Email = customer.Email;
            dto.Password = customer.Password;
            dto.UserType = customer.UserType;
            
            foreach (Purchased s in customer.PurchasedsAttended)
            {
                dto.PurchasedsAttended.Add(PurchasedDto.Create(s));
            }

            return dto;
        }

    }
}
