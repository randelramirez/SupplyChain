using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure.Models
{
    public interface IRepository: IDisposable
    {
        IQueryable<T> All<T>() where T : class, new();

        IQueryable<T> All<T>(params Expression<Func<T, object>>[] includeProperties) where T : class, new();

        T Single<T>(Func<T, bool> predicate) where T : class, new();

        T Find<T>(int? id) where T : class, new();

        void Add<T>(T entity) where T : class, new();

        void Update<T>(T entity) where T : class, new();

        void Delete<T>(T entity) where T : class, new();

    }
}
