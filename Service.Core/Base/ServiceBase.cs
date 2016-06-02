using AutoMapper;
using Domain.Base.UnitOfWork;
using Service.Core.Mapper;

namespace Service.Core.Base
{
    public class ServiceBase
    {
        protected readonly IUnitOfWork Uow;
        protected readonly IMapper Mapper;

        public ServiceBase(IUnitOfWork uow)
        {
            this.Uow = uow;

            if (AutoMapperConfiguration.MapperConfiguration == null)
            {
                AutoMapperConfiguration.Configure();
                Mapper = AutoMapperConfiguration.MapperConfiguration.CreateMapper();
            }
        }
    }
}
