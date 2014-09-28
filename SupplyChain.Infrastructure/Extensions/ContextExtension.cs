using SupplyChain.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure.Extensions
{
    public static class ContextExtension
    {
        //Only use with short lived contexts 
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IObjectWithState>())
            {
                IObjectWithState stateInfo = entry.Entity;
                entry.State = EntityStateHelper.ConvertState(stateInfo.State);
            }
        }

        public static void ApplyLogChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries().Where(e => e.Entity is ILogInfo && ((e.State == EntityState.Added) || e.State == EntityState.Modified)))
            {
                ((ILogInfo)entry.Entity).LastModified = DateTime.Now; //DateTime.UtcNow;
            }
        }
    }
}
