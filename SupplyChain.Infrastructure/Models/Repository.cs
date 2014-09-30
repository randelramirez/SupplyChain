using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SupplyChain.Core.Models;
using SupplyChain.Infrastructure.Extensions;

namespace SupplyChain.Infrastructure.Models
{
    public class Repository : IRepository
    {
        private IUnitOfWork uow;

        public Repository(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IQueryable<T> All<T>() where T : class, new()
        {
            return this.uow.Context.Set<T>();
        }

        public IQueryable<T> All<T>(params System.Linq.Expressions.Expression<Func<T, object>>[] includeProperties) where T : class, new()
        {
            var query = this.uow.Context.Set<T>().AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public T Single<T>(Func<T, bool> predicate) where T : class, new()
        {
            return this.uow.Context.Set<T>().Single(predicate);
        }

        public T Find<T>(int? id) where T : class, new()
        {
            return this.uow.Context.Set<T>().Find(id);
        }

        public void InsertOrUpdateGraph<T>(T entity) where T : class, IEntity<int>, new()
        {
            if (entity.State == State.Added)
            {
                this.uow.Context.Set<T>().Add(entity);
            }
            else
            {
                this.uow.Context.Set<T>().Add(entity);
                (this.uow.Context as DbContext).ApplyStateChanges();
            }
        }

        public void InsertOrUpdate<T>(T entity) where T : class, IEntity<int>, new()
        {
            if (entity.Id == default(int)) // New entity
            {
                (this.uow.Context as DbContext).Entry(entity).State = EntityState.Added;
            }
            else        // Existing entity
            {
                (this.uow.Context as DbContext).Entry(entity).State = EntityState.Modified;

            }
        }

        public void Delete<T>(T entity) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // TO DO check what to dispose, check if unit of work is disposable
            // try disposing the uow.context
            this.uow.Dispose();
            this.uow.Context.Dispose();
        }
    }
}
