using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Core.Models
{
    public interface ILogInfo
    {
        DateTime LastModified { get; set; }

        DateTime CreatedAt { get; set; }
    }
}
