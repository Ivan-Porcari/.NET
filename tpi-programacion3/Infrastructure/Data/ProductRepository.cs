using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Product?> GetProductList()
        {
            return _context.Products.Where(p => p.Activo).ToList();
        }

        public Product? GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id && x.Activo);
        }

        public bool CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateProduct(Product product)
        {
            var prod = _context.Products.FirstOrDefault(x => x.Id == product.Id && x.Activo);

            if (prod == null)
            {
                return false;
            }

            prod.Title = product.Title;
            prod.Band = product.Band;
            prod.PhotoURL = product.PhotoURL;
            prod.Category = product.Category;
            prod.Price = product.Price;
            prod.Discount = product.Discount;
            prod.Stock = product.Stock;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteProduct(Guid id)
        {
            var prod = _context.Products.FirstOrDefault(x => x.Id == id && x.Activo);

            if (prod == null)
            {
                return false;
            }

            prod.Activo = false;
            _context.SaveChanges();
            return true;
        }

        public bool ApplyDiscount(Guid id, double percentage)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id && x.Activo);

            if (product == null)
            {
                return false;
            }

            product.Price *= (1 - (percentage / 100));

            _context.SaveChanges();
            return true;
        }

    }
}
