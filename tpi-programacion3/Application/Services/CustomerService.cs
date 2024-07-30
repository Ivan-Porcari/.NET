using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ICollection<PurchasedDto> GetPurchasedsByCustomer(int customerId)
        {
            var purchaseds = _customerRepository.GetCustomerPurchaseds(customerId);

            return PurchasedDto.CreateList(purchaseds);

        }

    }
}

