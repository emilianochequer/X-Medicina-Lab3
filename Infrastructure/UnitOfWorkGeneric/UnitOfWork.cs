using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.Repository;
using Domain.Base.UnitOfWork;
using Infrastructure.Context;
using Infrastructure.RepositoryGeneric;

namespace Infrastructure.UnitOfWorkGeneric
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<string, object> _repositories;
        private readonly EfDbContext _context;
        private bool _disposed;

        public UnitOfWork(EfDbContext context)
        {
            this._context = context;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type)) return (Repository<TEntity>)_repositories[type];

            var repositoryType = typeof(Repository<>);
            var repositoryInstancie = Activator.CreateInstance(
                repositoryType.MakeGenericType(typeof(TEntity)), _context);
            _repositories.Add(type, repositoryInstancie);

            return (Repository<TEntity>)_repositories[type];
        }

        public IEnumerable<TEntity> EjecutarSp<TEntity>(string nombreSp,
            List<BaseParametroSP> parametros = null) where TEntity : BaseEntity
        {
            var objContext = ((IObjectContextAdapter)_context).ObjectContext;

            if (objContext.Connection.State != ConnectionState.Open)
                objContext.Connection.Open();

            var comando = objContext.Connection.CreateCommand();

            comando.CommandText = nombreSp.Trim();
            comando.CommandTimeout = TimeSpan.MaxValue.Milliseconds;
            comando.CommandType = CommandType.StoredProcedure;

            if (parametros != null)
            {
                foreach (var param in parametros)
                {
                    var parametroNuevo = comando.CreateParameter();
                    parametroNuevo.Direction = param.Direccion;
                    parametroNuevo.DbType = param.TipoParametro;
                    parametroNuevo.ParameterName = param.Nombre;
                    parametroNuevo.Value = param.Valor;

                    comando.Parameters.Add(parametroNuevo);
                }
            }

            var result = objContext.Translate<TEntity>(comando.ExecuteReader());

            return result.ToList();
        }

        public void EjecutarSp(string nombreSp, List<BaseParametroSP> parametros = null)
        {
            var objContext = ((IObjectContextAdapter)_context).ObjectContext;

            if (objContext.Connection.State != ConnectionState.Open)
                objContext.Connection.Open();

            var comando = objContext.Connection.CreateCommand();

            comando.CommandText = nombreSp.Trim();
            comando.CommandTimeout = TimeSpan.MaxValue.Milliseconds;
            comando.CommandType = CommandType.StoredProcedure;

            if (parametros != null)
            {
                foreach (var param in parametros)
                {
                    var parametroNuevo = comando.CreateParameter();
                    parametroNuevo.Direction = param.Direccion;
                    parametroNuevo.DbType = param.TipoParametro;
                    parametroNuevo.ParameterName = param.Nombre;
                    parametroNuevo.Value = param.Valor;

                    comando.Parameters.Add(parametroNuevo);
                }
            }

            objContext.ExecuteStoreCommandAsync(nombreSp, comando.Parameters);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
