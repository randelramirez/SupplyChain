using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SupplyChain.Web.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}