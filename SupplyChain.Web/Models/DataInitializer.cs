using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SupplyChain.Web.Models
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var people = new List<Person>
            {
                new Person { FirstName = "LeBron", LastName = "James", Birthday = new DateTime(1984,12,30), },
                new Person { FirstName = "Randel", LastName = "Ramirez", Birthday = new DateTime(1989,4,26), },
                new Person { FirstName = "Emi", LastName = "Honda", Birthday = new DateTime(1990,1,13), },
            };

            people.ForEach(p => context.People.Add(p));
            context.SaveChanges();
        }
    }
}