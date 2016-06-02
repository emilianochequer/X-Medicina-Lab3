using Domain.Base.Entity;
using Domain.Base.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Base.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        IEnumerable<TEntity> EjecutarSp<TEntity>(string nombreSp, List<BaseParametroSP> parametros = null) where TEntity : BaseEntity;

        void EjecutarSp(string nombreSp, List<BaseParametroSP> parametros = null);

        void Commit();
    }
}
