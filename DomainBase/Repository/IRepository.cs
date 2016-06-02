using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Base.Repository
{
    public interface IRepository<TEntity>
    {
        Guid Insert(TEntity entity);
        void Delete(Guid entityId);
        void Delete(TEntity entity);
        void Update(TEntity entity);

        TEntity GetById(Guid entityId, string includeProperties = null);
        TEntity GetById(Guid entityId, params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> GetAll(string includeProperties = null);
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> predicate,
            string includeProperties = null);

        IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
