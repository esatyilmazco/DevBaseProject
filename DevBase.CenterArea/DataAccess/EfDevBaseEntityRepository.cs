using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DevBase.CenterArea.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevBase.CenterArea.DataAccess
{
    public class EfDevBaseEntityRepository<TEntity, TContext> : IDevBaseEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using var contextValue = new TContext();
            return contextValue.Set<TEntity>().ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var contextValue = new TContext();
            return contextValue.Set<TEntity>().SingleOrDefault(filter);
        }

        public void Add(TEntity entity)
        {
            using var contextValue = new TContext();
            var addedEntity = contextValue.Entry(entity);
            addedEntity.State = EntityState.Added;
            contextValue.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using var contextValue = new TContext();
            var updatedEntity = contextValue.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            contextValue.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var contextValue = new TContext();
            var removedEntity = contextValue.Entry(entity);
            removedEntity.State = EntityState.Deleted;
            contextValue.SaveChanges();
        }
    }
}