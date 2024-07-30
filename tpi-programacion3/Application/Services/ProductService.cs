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
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product?> GetProductList()
        {
            return _repository.GetProductList();
        }

        public Product? GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public bool CreateProduct(Product product)
        {
            if (_repository.GetById(product.Id) != null)
            {
                return false;
            }

            return _repository.CreateProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return _repository.UpdateProduct(product);
        }

        public bool DeleteProduct(Guid id)
        {
            return _repository.DeleteProduct(id);
        }


    }
}
