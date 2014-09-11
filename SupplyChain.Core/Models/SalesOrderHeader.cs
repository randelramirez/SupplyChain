using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Core.Models
{
    public class SalesOrderHeader : ILog
    {
        public SalesOrderHeader()
        {
            this.CreatedAt = DateTime.Now;//DateTime.UtcNow;
            this.LastModified = DateTime.Now;//DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public DateTime LastModified { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
       
    }
}
