using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using Domain.Base.Entity;
using Domain.Base.Repository;
using Infrastructure.Context;

namespace Infrastructure.RepositoryGeneric
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly EfDbContext _context;
        private IDbSet<TEntity> _entities;

        public Repository()
        {
            if (this._context == null)
                this._context = new EfDbContext();
        }

        public Guid Insert(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException($"La entidad {nameof(entity)} no puede ser null");

                this.Entities.Add(entity);

                return entity.Id;
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetMessageError(dbEx), dbEx);
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException($"La entidad {nameof(entity)} no puede ser null");

                this._context.Entry(entity).State = EntityState.Modified;
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetMessageError(dbEx), dbEx);
            }

        }

        public void Delete(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException($"La entidad {nameof(entity)} no puede ser null");

                this._context.Entry(entity).State = EntityState.Deleted;
                this.Entities.Remove(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetMessageError(dbEx), dbEx);
            }
        }

        public void Delete(Guid entityId)
        {
            try
            {
                var entity = this.Entities.FirstOrDefaultAsync(x => x.Id == entityId);
                this.Entities.Remove(entity.Result);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetMessageError(dbEx), dbEx);
            }
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = this.Entities;

            query = includeProperties.Aggregate(query, (current, includeProperty)
                => current.Include(includeProperty));

            return query.ToList();
        }

        public IEnumerable<TEntity> GetAll(string includeProperties = null)
        {
            IQueryable<TEntity> query = this.Entities;

            if (includeProperties == null) return query.ToList();

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, include) => current.Include(include));

            return query.ToList();
        }

        public IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = this.Entities;

            query = includeProperties.Aggregate(query, (current, includeProperty)
                => current.Include(includeProperty));

            return query.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> predicate, string includeProperties = null)
        {
            IQueryable<TEntity> query = this.Entities;

            if (includeProperties == null) return query.ToList();

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, include) => current.Include(include));

            return query.Where(predicate).ToList();
        }

        public TEntity GetById(Guid entityId, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = this.Entities;

            query = includeProperties.Aggregate(query, (current, includeProperty)
                => current.Include(includeProperty));

            return query.FirstOrDefault(x => x.Id == entityId);
        }

        public TEntity GetById(Guid entityId, string includeProperties = null)
        {
            IQueryable<TEntity> query = this.Entities;

            if (includeProperties == null) return query.FirstOrDefault(x => x.Id == entityId);

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, include) => current.Include(include));

            return query.FirstOrDefault(x => x.Id == entityId);
        }

        // Metodos Privados
        private IDbSet<TEntity> Entities => this._entities ??
            (this._entities = this._context.Set<TEntity>());

        private static string GetMessageError(DbEntityValidationException dbEx)
        {
            return dbEx.EntityValidationErrors.SelectMany(validationErrors
                => validationErrors.ValidationErrors).Aggregate(string.Empty, (current, validationError)
                => current + ($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}"
                + Environment.NewLine));
        }
    }
}
