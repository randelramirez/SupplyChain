using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupplyChain.Infrastructure.Models
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        IContext Context { get; }
    }
}
