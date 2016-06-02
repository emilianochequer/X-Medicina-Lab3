using Domain.Base.Repository;
using Domain.Base.UnitOfWork;
using Domain.Core.Entities.Validation;
using Infrastructure.Context;
using Infrastructure.RepositoryGeneric;
using Infrastructure.UnitOfWorkGeneric;
using Microsoft.Practices.Unity;
using Service.Core.ObraSocial;
using Unity.Wcf;

namespace WcfService.Core
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<EfDbContext>(new HierarchicalLifetimeManager())
                .RegisterType(typeof (IUnitOfWork), typeof (UnitOfWork))
                .RegisterType(typeof (IRepository<>), typeof (Repository<>))
                .RegisterType<IServicePaciente, ServicePaciente>()
                .RegisterType<IObraSocialService, ObraSocialService>();
        }
    }    
}