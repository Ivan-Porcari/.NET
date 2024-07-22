using Application.Models;
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

        public CustomerDto GetCustomerById(int id)
        {
            var customer = _customerRepository.GetById(id);
            return customer != null ? CustomerDto.Create(customer) : null;
        }

        public ICollection<CustomerDto> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll();
            return CustomerDto.CreateList(customers);
        }
    }
}
