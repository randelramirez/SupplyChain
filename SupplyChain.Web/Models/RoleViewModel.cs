using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupplyChain.Web.Models
{
    public class RoleViewModel
    {
        // Change the Id type from string to int:
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
  
}