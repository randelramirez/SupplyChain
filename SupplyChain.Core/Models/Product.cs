using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Core.Models
{
    public class Product : IEntity<int>, IObjectWithState
    {
        public Product()
        {
            this.CreatedAt = DateTime.Now; //DateTime.UtcNow;
            this.LastModified = DateTime.Now; //DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }

        public DateTime LastModified { get; set; }


        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public State State { get; set; }

    }
}
