using Application.Interfaces;
using Application.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PurchasedService : IPurchasedService
    {
        private readonly IPurchasedRepository _purchasedRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public PurchasedService(IPurchasedRepository purchasedRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _purchasedRepository = purchasedRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public PurchasedDto GetPurchasedByCustomerName(string customerName)
        {
            var customer = _userRepository.GetByName(customerName);
            if (customer == null)
            {
                throw new InvalidOperationException($"No se encontro el carrito de compras del clientecon nombre {customerName}");
            }

            var purchased = _purchasedRepository.GetPurchasedByCustomerId(customer.Id);

            if (purchased == null)
            {
                throw new InvalidOperationException($"No se encontro el carrito de compras del cliente con con ID {customer.Id}");
            }

            return new PurchasedDto
            {
                IdPurchased = purchased.IdPurchased,
                Tax = purchased.Tax,
                CustomerId = purchased.CustomerId,
                Products = purchased.Products.Select(p => p.Title).ToList(),
                SubTotal = purchased.SubTotal,
                Customer = new UserDto
                {
                    Name = customer.Name,
                    Email = customer.Email,
                }
            };
        }

        public bool AddProductToCart(string customerName, Guid productId)
        {
            var customer = _userRepository.GetByName(customerName);
            if (customer == null)
            {
                return false;
            }

            var purchased = _purchasedRepository.GetPurchasedByCustomerId(customer.Id);
            var product = _productRepository.GetById(productId);

            if (purchased == null || product == null)
            {
                return false;
            }

            purchased.Products.Add(product);
            _purchasedRepository.UpdatePurchased(purchased);
            return true;
        }

        public bool RemoveProductFromCart(string customerName, Guid productId)
        {
            var customer = _userRepository.GetByName(customerName);
            if (customer == null)
            {
                return false;
            }

            var purchased = _purchasedRepository.GetPurchasedByCustomerId(customer.Id);
            var product = _productRepository.GetById(productId);

            if (purchased== null || product == null)
            {
                return false;
            }

            purchased.Products.Remove(product);
            _purchasedRepository.UpdatePurchased(purchased);
            return true;
        }
    }
}
