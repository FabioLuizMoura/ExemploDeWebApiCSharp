using Domain.Interfaces;
using Infra.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected Context db = new Context();
        public void Add(TEntity obj)
        {
            db.Set<TEntity>().Add(obj);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }
        public TEntity GetById(int id)
        {
            return db.Set<TEntity>().Find(id);
        }
        public void Remove(int id)
        {
            db.Set<TEntity>().Remove(this.GetById(id));
            db.SaveChanges();
        }
        public void Update(TEntity obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
