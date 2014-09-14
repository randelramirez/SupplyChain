using SupplyChain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure.DataInitializer
{
    public static class CustomerDataInitializer
    {
        public static List<Customer> CreateCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer { Name = "Spotify", SalesOrder = new List<SalesOrderHeader> {new SalesOrderHeader { Date = DateTime.Now.AddDays(5)} }},
                new Customer { Name = "Infor" },
                new Customer { Name = "HP"},
                new Customer { Name = "Novare"},
                new Customer { Name = "GlobalTrack"},
            };

            return customers;
        }
    }
}
