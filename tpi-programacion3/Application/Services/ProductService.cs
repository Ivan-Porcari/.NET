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
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductDto GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            return product != null ? ProductDto.Create(product) : null;
        }

        public ICollection<ProductDto> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return ProductDto.CreateList(products);
        }


    }
}
