using System;
using System.Collections.Generic;
using Domain.Base.UnitOfWork;
using Service.Core.ObraSocial.DTOs;
using System.Linq;
using Domain.Core.Entities;
using Application.Extensions;
using System.Linq.Expressions;

namespace Service.Core.ObraSocial
{
    public class ObraSocialService : Base.ServiceBase, IObraSocialService
    {
        public ObraSocialService(IUnitOfWork uow)
            : base(uow)
        { 
        }

        public void Delete(Guid obraSocialId)
        {
            var eliminarOS = Uow.Repository<Domain.Core.Entities.ObraSocial>().GetById(obraSocialId);
            eliminarOS.EstaActivo = false;
            Uow.Repository<Domain.Core.Entities.ObraSocial>().Update(eliminarOS);
            Uow.Commit();
            
        }

        public IEnumerable<ObraSocialDto> GetAll()
        {
            var listaOs = Uow.Repository<Domain.Core.Entities.ObraSocial>().GetAll();
            var listaDto = Mapper.Map<IEnumerable< Domain.Core.Entities.ObraSocial>, IEnumerable< ObraSocialDto>>(listaOs.ToList());
            return listaDto; 
        }

        public IEnumerable<ObraSocialDto> GetByFilter(string cadena)
        {
            Expression<Func<Domain.Core.Entities.ObraSocial, bool>> pred = x => false;
            if (!string.IsNullOrEmpty(cadena))
            {
                pred = pred.And(x => x.Codigo.ToString() == cadena);
                pred = pred.And(x => x.EstaActivo);
            }
            var listaOs = Uow.Repository<Domain.Core.Entities.ObraSocial>().GetByFilter(pred);
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.ObraSocial>,IEnumerable< ObraSocialDto>>(listaOs.ToList());
            return listaDto.ToList();
        }

        public ObraSocialDto GetById(Guid obraSocialId)
        {
            var listaObraSocial = Uow.Repository<Domain.Core.Entities.ObraSocial>().GetById(obraSocialId);

            var listaDto = Mapper.Map<Domain.Core.Entities.ObraSocial, 
                ObraSocialDto>(listaObraSocial);
            return listaDto;
        }

        public void Insertar(ObraSocialDto obraSocial)
        {
            var obraSocialNueva = Mapper.Map<ObraSocialDto, Domain.Core.Entities.ObraSocial>(obraSocial);
            Uow.Repository<Domain.Core.Entities.ObraSocial>()
                .Insert(obraSocialNueva);
            Uow.Commit();
        }

        public void Update(ObraSocialDto obraSocial)
        {
            var obraSocialModificar = Mapper.Map<ObraSocialDto, Domain.Core.Entities.ObraSocial>(obraSocial);
            Uow.Repository<Domain.Core.Entities.ObraSocial>().Update(obraSocialModificar);
            Uow.Commit();
        }
    }
}
