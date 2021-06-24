using Microsoft.EntityFrameworkCore;
using PSV.Core;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace PSV.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public PSVContext PsvContext {
            get { return Context as PSVContext; }
        }


        public Repository(DbContext context) {
            Context = context;
        }

        public TEntity Get(int id) {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) {
            return (IEnumerable<TEntity>)Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity) {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities) {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity) {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity) {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Detach(TEntity entity) {
            Context.Entry(entity).State = EntityState.Detached;
        }

        public virtual IEnumerable<TEntity> GetAll() {
            return Context.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<Entity> Search(string term= "")
        {
            throw new NotImplementedException();
        }

        public virtual PageResponse<TEntity> GetPage(PageModel model) {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepository<TEntity>.Search(string term)
        {
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
