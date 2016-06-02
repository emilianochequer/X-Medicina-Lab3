using System;
using System.Collections.Generic;
using Domain.Base.UnitOfWork;
using Domain.Core.Entities;
using Service.Core.Alimento.DTOs;
using Service.Core.Base;
using System.Linq.Expressions;
using System.Linq;
using Application.Extensions;

namespace Service.Core.Alimento
{
    public class ServiceAlimento : ServiceBase, IServiceAlimento
    {
        
        public ServiceAlimento(IUnitOfWork uow)
            :base(uow)
        {
                
        }

        public void Delete(Guid alimentoId)
        {
            var alimentoEliminar = Uow.Repository<Domain.Core.Entities.Alimento>().GetById(alimentoId);
            alimentoEliminar.EstaActivo = false;
            Uow.Repository<Domain.Core.Entities.Alimento>().Update(alimentoEliminar);
            Uow.Commit();
        }

        public IEnumerable<AlimentoDto> GetAll()
        {
            var listaAlimento = Uow.Repository<Domain.Core.Entities.Alimento>().GetAll();

            var listaDto = Mapper.Map< IEnumerable< Domain.Core.Entities.Alimento>, IEnumerable<AlimentoDto>>(listaAlimento.ToList());

            return listaDto;
        }

        public IEnumerable<AlimentoDto> GetByFilter(string cadena)
        {
            Expression<Func<Domain.Core.Entities.Alimento, bool>> pred = x => true;
            if (!string.IsNullOrEmpty(cadena))
            {
                pred = pred.And(x => x.Descripcion.Contains(cadena));
                pred = pred.And(x => x.EstaActivo);
            }
            var listaAlimentos = Uow.Repository<Domain.Core.Entities.Alimento>().GetByFilter(pred);
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.Alimento>, IEnumerable<AlimentoDto>>(listaAlimentos.ToList());
            return listaDto.ToList();
        }

        public AlimentoDto GetById(Guid alimentoId)
        {
            var listaAlimento = Uow.Repository<Domain.Core.Entities.Alimento>().GetById(alimentoId);

            var listaDto = Mapper.Map<Domain.Core.Entities.Alimento, AlimentoDto>(listaAlimento);

            return listaDto;
        }

        public void Insert(AlimentoDto alimento)
        {
            var alimentoNuevo = Mapper.Map<AlimentoDto, Domain.Core.Entities.Alimento>(alimento);
            Uow.Repository<Domain.Core.Entities.Alimento>().Insert((Domain.Core.Entities.Alimento)alimentoNuevo);
            Uow.Commit();
        }

        public void Update(AlimentoDto alimento)
        {
            var alimentoModificar = Mapper.Map<AlimentoDto, Domain.Core.Entities.Alimento>(alimento);
            Uow.Repository<Domain.Core.Entities.Alimento>().Update((Domain.Core.Entities.Alimento)alimentoModificar);
            Uow.Commit();
        }
       
    }
}
