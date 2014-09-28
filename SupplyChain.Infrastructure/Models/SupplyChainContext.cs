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
    public class SupplyChainContext : DbContext, IContext
    {
        public SupplyChainContext()
        {

        }

        static SupplyChainContext()
        {
            Database.SetInitializer<OldSupplyChainContext>(new SupplyChainDataInitializer());
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


        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void SetAdd(object entity)
        {
            Entry(entity).State = EntityState.Added;
        }
    }
}
