﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Core.Models
{
    public class BusinessPartner : ILog
    {
        public BusinessPartner()
        {
            this.CreatedAt = DateTime.Now;//DateTime.UtcNow;
            this.LastModified = DateTime.Now;//DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime LastModified { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
