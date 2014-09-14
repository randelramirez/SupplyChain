using SupplyChain.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure.DataInitializer
{
    public class SupplyChainDataInitializer : DropCreateDatabaseIfModelChanges<SupplyChainContext>
    {
        protected override void Seed(SupplyChainContext context)
        {
            //base.Seed(context);
            var customers = CustomerDataInitializer.CreateCustomers();
            customers.ForEach(c => context.Customers.Add(c));

            var suppliers = SupplierDataInitializer.CreateSuppliers();
            suppliers.ForEach(s => context.Suppliers.Add(s));
            
            var products = ProductDataInitializer.CreateProducts();
            products.ForEach(p => context.Products.Add(p));

            context.SaveChangesAsync();
        }
    }
}
