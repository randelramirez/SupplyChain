using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Core.Models
{
    public interface IObjectWithState
    {
        State State { get; set; }
    }
    public enum State
    {
        Added,
        Unchanged,
        Modified,
        Deleted
    }
}
