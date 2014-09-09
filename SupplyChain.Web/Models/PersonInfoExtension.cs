using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChain.Web.Models
{
    public static class PersonInfoExtension
    { 
        public static string GetFullname(this Person person)
        {
            return person.FirstName + " " + person.LastName;
        }

        public static int GetAge(this Person person)
        {

            var birthday = person.Birthday; 
            DateTime now = DateTime.Today;
            int age = now.Year - person.Birthday.Year;
            if (now < birthday.AddYears(age)) 
            {
                age--;
            };
            return age;
        }
    }
}