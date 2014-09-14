using SupplyChain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace SupplyChain.Infrastructure.Models
{
    public class Repository : IRepository, IDisposable
    {

        public Repository()
        {
        }

        private SupplyChainContext context = new SupplyChainContext();

        public IQueryable<T> All<T>() where T : class, new()
        {
            return this.context.Set<T>();
        }

        public IQueryable<T> All<T>(params Expression<Func<T, object>>[] includeProperties) where T : class, new()
        {
            var query = this.context.Set<T>().AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public T Single<T>(Func<T,bool> predicate) where T : class, new()
        {
            return this.context.Set<T>().Single(predicate);
        }

        public T Find<T>(int? id) where T : class, new()
        {
            return this.context.Set<T>().Find(id);
        }

        public void Add<T>(T model) where T : class, new()
        {
            this.context.Set<T>().Add(model);
        }

        public void Update<T>(T model) where T : class, new()
        {
            //this.context.Set<T>().Attach(model);
            this.context.Entry(model).State = EntityState.Modified;
        }

        public void Delete<T>(T entity) where T: class, new()
        {
            this.context.Set<T>().Remove(entity);
        }

        public int Save()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
