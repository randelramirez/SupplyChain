﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Core.Models
{
    public class Customer : BusinessPartner
    {
        public Customer(): base()
        {

        }

        public ICollection<SalesOrderHeader> SalesOrder { get; set; }
    }
}
