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
        private readonly IContext _context;

        public UnitOfWork()
        {
            _context = new TContext();
        }

        public UnitOfWork(IContext context)
        {
            _context = context;
        }
        public int Save()
        {
            (this.Context as DbContext).ApplyLogChanges();
            return _context.SaveChanges();
        }

        public IContext Context
        {
            get { return (TContext)_context; }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
