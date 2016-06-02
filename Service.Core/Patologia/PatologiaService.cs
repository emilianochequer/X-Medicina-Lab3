using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Core.Patologia.DTOs;
using Domain.Base.UnitOfWork;
using System.Linq.Expressions;
using Application.Extensions;

namespace Service.Core.Patologia
{
    public class PatologiaService : Base.ServiceBase, IPatologiaService
    {
        public PatologiaService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public void Delete(Guid patologiaId)
        {
            var eliminarPatologia = Uow.Repository<Domain.Core.Entities.Patologia>().GetById(patologiaId);
            eliminarPatologia.EstaActivo = false;
            Uow.Repository<Domain.Core.Entities.Patologia>().Update(eliminarPatologia);
            Uow.Commit();
        }

        public IEnumerable<PatologiaDto> GetAll()
        {
            var listapatologia = Uow.Repository<Domain.Core.Entities.Patologia>().GetAll();
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.Patologia>, IEnumerable<PatologiaDto>>(listapatologia.ToList());
            return listaDto;
        }

        public IEnumerable<PatologiaDto> GetByFilter(string cadena)
        {
            Expression<Func<Domain.Core.Entities.Patologia, bool>> pred = x => false;
            if (!string.IsNullOrEmpty(cadena))
            {
                pred = pred.And(x => x.Descripcion.Contains(cadena));
                pred = pred.And(x => x.EstaActivo);
            }
            var listaPatologia = Uow.Repository<Domain.Core.Entities.Patologia>().GetByFilter(pred);
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.Patologia>, IEnumerable<PatologiaDto>>(listaPatologia.ToList());
            return listaDto.ToList();
        }

        public PatologiaDto GetById(Guid patologiaId)
        {
            var listaPatologia = Uow.Repository<Domain.Core.Entities.Patologia>().GetById(patologiaId);

            var listaDto = Mapper.Map<Domain.Core.Entities.Patologia,
                PatologiaDto>(listaPatologia);
            return listaDto;
        }

        public void Insert(PatologiaDto patologia)
        {
            var patologiaNueva = Mapper.Map<PatologiaDto, Domain.Core.Entities.Patologia>(patologia);
            Uow.Repository<Domain.Core.Entities.Patologia>()
                .Insert(patologiaNueva);
            Uow.Commit();
        }

        public void Update(PatologiaDto patologia)
        {
            var patologiaModificar = Mapper.Map<PatologiaDto, Domain.Core.Entities.Patologia>(patologia);
            Uow.Repository<Domain.Core.Entities.Patologia>().Update(patologiaModificar);
            Uow.Commit();
        }
    }
}
