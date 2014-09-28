using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure.Models
{
    public interface IContext : IDisposable
    {
        int SaveChanges();
        void SetModified(object entity);
        void SetAdd(object entity);

        DbSet<T> Set<T>() where T: class;
    }
}
