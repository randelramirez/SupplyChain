using SupplyChain.Core.Models;
using SupplyChain.Infrastructure.DataInitializer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure.Models
{
    public class SupplyChainContext : DbContext
    {
        public SupplyChainContext()
        {

        }

        static SupplyChainContext()
        {
            Database.SetInitializer<SupplyChainContext>(new SupplyChainDataInitializer());
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().Map(m =>
            {
                //m.MapInheritedProperties();
                m.ToTable("Customers");
            });

            modelBuilder.Entity<Supplier>().Map(m =>
            {
                //m.MapInheritedProperties();
                m.ToTable("Suppliers");
            });            
        }
    }
}
