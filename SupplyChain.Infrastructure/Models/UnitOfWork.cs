using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupplyChain.Infrastructure.Extensions;

namespace SupplyChain.Infrastructure.Models
{
    public class UnitOfWork<TContext> : IUnitOfWork
      where TContext : IContext, new()
    {
        private readonly IContext context;

        public UnitOfWork()
        {
            this.context = new TContext();
        }

        public UnitOfWork(IContext context)
        {
            this.context = context;
        }
        public int Save()
        {
            (this.Context as DbContext).ApplyLogChanges();
            return context.SaveChanges();
        }

        public IContext Context
        {
            get { return (TContext)context; }
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
