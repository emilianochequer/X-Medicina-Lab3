using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Core.MotivoConsulta.DTOs;
using Domain.Base.UnitOfWork;
using System.Linq.Expressions;
using Application.Extensions;

namespace Service.Core.MotivoConsulta
{
    public class ServiceMotivoConsulta : Base.ServiceBase, IServiceMotivoConsulta
    {
        public ServiceMotivoConsulta(IUnitOfWork uow)
            : base(uow)
        {
        }

        public void Delete(Guid motivoConsultaId)
        {
            var eliminarMC = Uow.Repository<Domain.Core.Entities.MotivoConsulta>().GetById(motivoConsultaId);
            eliminarMC.EstaActivo = false;
            Uow.Repository<Domain.Core.Entities.MotivoConsulta>().Update(eliminarMC);
            Uow.Commit();
        }

        public IEnumerable<MotivoConsultaDto> GetAll()
        {
            var listaMc = Uow.Repository<Domain.Core.Entities.MotivoConsulta>().GetAll();
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.MotivoConsulta>, IEnumerable<MotivoConsultaDto>>(listaMc.ToList());
            return listaDto;
        }

        public IEnumerable<MotivoConsultaDto> GetByFilter(string cadena)
        {
            Expression<Func<Domain.Core.Entities.MotivoConsulta, bool>> pred = x => false;
            if (!string.IsNullOrEmpty(cadena))
            {
                pred = pred.And(x => x.Descripcion.Contains(cadena));
                pred = pred.And(x => x.EstaActivo);

            }
            var listaMc = Uow.Repository<Domain.Core.Entities.MotivoConsulta>().GetByFilter(pred);
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.MotivoConsulta>, IEnumerable<MotivoConsultaDto>>(listaMc.ToList());
            return listaDto.ToList();
        }

        public MotivoConsultaDto GetById(Guid motivoConsultaId)
        {
            var listaMc = Uow.Repository<Domain.Core.Entities.MotivoConsulta>().GetById(motivoConsultaId);

            var listaDto = Mapper.Map<Domain.Core.Entities.MotivoConsulta,
                MotivoConsultaDto>(listaMc);
            return listaDto;
        }

        public void Insert(MotivoConsultaDto motivoConsulta)
        {
            var motivoConsultaNueva = Mapper.Map<MotivoConsultaDto, Domain.Core.Entities.MotivoConsulta>(motivoConsulta);
            Uow.Repository<Domain.Core.Entities.MotivoConsulta>()
                .Insert(motivoConsultaNueva);
            Uow.Commit();
        }

        public void Update(MotivoConsultaDto motivoConsulta)
        {
            var motivoConsultaModificar = Mapper.Map<MotivoConsultaDto, Domain.Core.Entities.MotivoConsulta>(motivoConsulta);
            Uow.Repository<Domain.Core.Entities.MotivoConsulta>().Update(motivoConsultaModificar);
            Uow.Commit();
        }
    }
}
