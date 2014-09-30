using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Core.Models
{
    public class SalesOrderDetail : IEntity<int>, IObjectWithState
    {
        public SalesOrderDetail()
        {
            this.CreatedAt = DateTime.Now;//DateTime.UtcNow;
            this.LastModified = DateTime.Now;//DateTime.UtcNow;
        }

        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int SalesOrderHeaderId { get; set; }

        public virtual Product Product { get; set; }

        public virtual SalesOrderHeader SalesOrderHeader { get; set; }


        public DateTime LastModified { get; set; }


        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public State State { get; set; }

    }
}
