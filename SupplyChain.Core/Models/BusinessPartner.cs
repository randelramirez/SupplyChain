using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplyChain.Core.Models
{
    public class BusinessPartner : IEntity<int>, IObjectWithState
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

        [NotMapped]
        public State State { get; set; }
    }
}
