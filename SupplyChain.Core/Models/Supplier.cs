﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupplyChain.Core.Models
{
    public class Supplier : BusinessPartner
    {
        public Supplier() : base()
        {

        }

        public ICollection<Product> Products {get; set; }
    }
}
