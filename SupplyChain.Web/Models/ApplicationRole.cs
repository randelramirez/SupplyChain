using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplyChain.Web.Models
{

    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>, IRole<int>
    {
        public ApplicationRole() 
        {
 
        }
        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
        }

        public string Description { get; set; }  // Custom description field on roles
    }
}