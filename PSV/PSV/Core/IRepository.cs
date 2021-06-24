using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PSV.Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Search(string term = "");

        PageResponse<TEntity> GetPage(PageModel model);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void Detach(TEntity entity);
    }
}
