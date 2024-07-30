using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Band { get; set; }
        public string PhotoURL { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int? Stock { get; set; }

        public static ProductDto Create(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Title = product.Title,
                Band = product.Band,
                PhotoURL = product.PhotoURL,
                Category = product.Category,
                Price = product.Price,
                Stock = product.Stock
            };
        }

    }
}
