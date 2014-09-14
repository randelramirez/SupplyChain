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
        // TO DO: method overload of GetAll that accepts an include expression

        public Repository()
        {
        }

        private SupplyChainContext context = new SupplyChainContext();

        public IQueryable<T> GetAll<T>() where T : class, new()
        {
            return this.context.Set<T>();
        }

        public T GetSingle<T>(Func<T,bool> predicate) where T : class, new()
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

        public IQueryable<Customer> All123<T>(params Expression<Func<T, object>>[] expression) where T: class, new()
        {
            //var query = this.context.Set<T>().AsQueryable();
            ////return this.context.Set<T>();//.Include("");
            ////this.context.Products.Include(expression);
            //foreach (var inc in expression)
            //{
            //    query = query.Include(inc);
            //}

            //return query.AsQueryable();

            var query = this.context.Customers.Include(m => m.SalesOrder);
            return query;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
