using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Core.Familiares.DTOs;
using Domain.Base.UnitOfWork;
using System.Linq.Expressions;
using Application.Extensions;

namespace Service.Core.Familiares
{
    public class FamiliarService : Base.ServiceBase, IFamiliarService
    {
        public FamiliarService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public void Delete(Guid familiarId)
        {
            var eliminarFamiliar = Uow.Repository<Domain.Core.Entities.Familiar>().GetById(familiarId);
            eliminarFamiliar.EstaActivo = false;
            Uow.Repository<Domain.Core.Entities.Familiar>().Update(eliminarFamiliar);
            Uow.Commit();
        }

        public IEnumerable<FamiliarDto> GetAll()
        {
            var listaFamiliar = Uow.Repository<Domain.Core.Entities.Familiar>().GetAll();
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.Familiar>, IEnumerable<FamiliarDto>>(listaFamiliar.ToList());
            return listaDto;
        }

        public IEnumerable<FamiliarDto> GetByFilter(string cadena)
        {
            Expression<Func<Domain.Core.Entities.Familiar, bool>> pred = x => false;
            if (!string.IsNullOrEmpty(cadena))
            {
                pred = pred.And(x => x.Apellido.Contains(cadena)
                                || x.Nombre.Contains(cadena)
                                || x.Dni == cadena
                                || x.Telefono == cadena);
                pred = pred.And(x => x.EstaActivo);
            }
            var listaFamiliar = Uow.Repository<Domain.Core.Entities.Familiar>().GetByFilter(pred);
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.Familiar>, IEnumerable<FamiliarDto>>(listaFamiliar.ToList());
            return listaDto.ToList();
        }

        public FamiliarDto GetById(Guid familiarId)
        {
            var listaFamiliar = Uow.Repository<Domain.Core.Entities.Familiar>().GetById(familiarId);

            var listaDto = Mapper.Map<Domain.Core.Entities.Familiar,
                FamiliarDto>(listaFamiliar);
            return listaDto;
        }

        public void Insert(FamiliarDto familiar)
        {
            var familiarNueva = Mapper.Map<FamiliarDto, Domain.Core.Entities.Familiar>(familiar);
            Uow.Repository<Domain.Core.Entities.Familiar>()
                .Insert(familiarNueva);
            Uow.Commit();
        }

        public void Update(FamiliarDto familiar)
        {
            var familiarModificar = Mapper.Map<FamiliarDto, Domain.Core.Entities.Familiar>(familiar);
            Uow.Repository<Domain.Core.Entities.Familiar>().Update(familiarModificar);
            Uow.Commit();
        }
    }
}
