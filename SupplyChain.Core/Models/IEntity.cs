using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Core.Models
{
    public interface IEntity<T> : IObjectWithState
    {
        T Id { get; set; }
    }
}
