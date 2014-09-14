using SupplyChain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure.DataInitializer
{
    public static class ProductDataInitializer
    {
        public static List<Product> CreateProducts()
        {
            var products = new List<Product>()
            {
                new Product { Name = "iPhone 6"},
                new Product { Name = "iPhone 6 Plus"},
                new Product { Name = "Samsung Galaxy S5"},
                new Product {Name = "Gel Lyte III Nippon Blues"},
                new Product { Name = "Gel Lyte III Aztec"}
            };

            return products;
        }
    }
}
