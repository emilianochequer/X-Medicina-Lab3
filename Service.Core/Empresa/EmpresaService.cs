using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Core.Empresa.DTOs;
using Domain.Base.UnitOfWork;
using System.Linq.Expressions;
using Application.Extensions;

namespace Service.Core.Empresa
{
    public class EmpresaService : Base.ServiceBase, IEmpresaService
    {
        public EmpresaService(IUnitOfWork uow)
            : base(uow)
        {
        }
        public void Delete(Guid empresaId)
        {
            var eliminarEmpresa = Uow.Repository<Domain.Core.Entities.Empresa>().GetById(empresaId);
            eliminarEmpresa.EstaActivo = false;
            Uow.Repository<Domain.Core.Entities.Empresa>().Update(eliminarEmpresa);
            Uow.Commit();
        }

        public IEnumerable<EmpresaDto> GetAll()
        {
            var listaEmpresa = Uow.Repository<Domain.Core.Entities.Empresa>().GetAll();
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.Empresa>, IEnumerable<EmpresaDto>>(listaEmpresa.ToList());
            return listaDto;
        }

        public IEnumerable<EmpresaDto> GetByFilter(string cadena)
        {
            Expression<Func<Domain.Core.Entities.Empresa, bool>> pred = x => false;
            if (!string.IsNullOrEmpty(cadena))
            {
                pred = pred.And(x => x.NombreFantasia.Contains(cadena)
                                || x.Domicilio == cadena);
                pred = pred.And(x => x.EstaActivo);
            }
            var listaempresa = Uow.Repository<Domain.Core.Entities.Empresa>().GetByFilter(pred);
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.Empresa>, IEnumerable<EmpresaDto>>(listaempresa.ToList());
            return listaDto.ToList();
        }

        public EmpresaDto GetById(Guid empresaId)
        {
            var listaEmpresa = Uow.Repository<Domain.Core.Entities.Empresa>().GetById(empresaId);

            var listaDto = Mapper.Map<Domain.Core.Entities.Empresa,
                EmpresaDto>(listaEmpresa);
            return listaDto;
        }

        public void Insert(EmpresaDto empresa)
        {
            var empresaNueva = Mapper.Map<EmpresaDto, Domain.Core.Entities.Empresa>(empresa);
            Uow.Repository<Domain.Core.Entities.Empresa>()
                .Insert(empresaNueva);
            Uow.Commit();
        }

        public void Update(EmpresaDto empresa)
        {
            var empresaModificar = Mapper.Map<EmpresaDto, Domain.Core.Entities.Empresa>(empresa);
            Uow.Repository<Domain.Core.Entities.Empresa>().Update(empresaModificar);
            Uow.Commit();
        }
    }
}
