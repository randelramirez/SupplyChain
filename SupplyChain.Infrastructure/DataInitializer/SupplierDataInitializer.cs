using SupplyChain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure.DataInitializer
{
    public static class SupplierDataInitializer
    {
        public static List<Supplier> CreateSuppliers()
        {
            var suppliers = new List<Supplier>()
            {
                new Supplier { Name = "Apple"},
                new Supplier { Name = "Asics"},
                new Supplier { Name = "Nike"},
                new Supplier { Name = "Microsoft"},
                new Supplier { Name = "AcneCure"}
            };

            return suppliers;
        }
    }
}
