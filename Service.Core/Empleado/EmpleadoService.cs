using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Core.Empleado.DTOs;
using Domain.Base.UnitOfWork;
using System.Linq.Expressions;
using Application.Extensions;

namespace Service.Core.Empleado
{
    public class EmpleadoService : Base.ServiceBase, IEmpleadoService
    {
        public EmpleadoService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public void Delete(Guid empleadoId)
        {
            var empleadoEliminar = Uow.Repository<Domain.Core.Entities.Empleado>().GetById(empleadoId);
            empleadoEliminar.EstaActivo = false;
            Uow.Repository<Domain.Core.Entities.Empleado>().Update(empleadoEliminar);
            Uow.Commit();
        }

        public IEnumerable<EmpleadoDto> GetAll()
        {
            var listaEmpleado = Uow.Repository<Domain.Core.Entities.Empleado>().GetAll();

            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.Empleado>, IEnumerable<EmpleadoDto>>(listaEmpleado.ToList());

            return listaDto;
        }

        public IEnumerable<EmpleadoDto> GetByFilter(string cadena)
        {
            Expression<Func<Domain.Core.Entities.Empleado, bool>> pred = x => true;
            if (!string.IsNullOrEmpty(cadena))
            {
                pred = pred.And(x => x.Nombre.Contains(cadena)
                                || x.Apellido.Contains(cadena)
                                || x.Dni == cadena);
                pred = pred.And(x => x.EstaActivo);
            }
            var listaEmpleado = Uow.Repository<Domain.Core.Entities.Empleado>().GetByFilter(pred);
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.Empleado>, IEnumerable<EmpleadoDto>>(listaEmpleado.ToList());
            return listaDto.ToList();
        }

        public EmpleadoDto GetById(Guid empleadoId)
        {
            var listaEmpleado = Uow.Repository<Domain.Core.Entities.Empleado>().GetById(empleadoId);
            var listaDto = Mapper.Map<Domain.Core.Entities.Empleado, EmpleadoDto>(listaEmpleado);
            return listaDto;
        }

        public void Insert(EmpleadoDto empleado)
        {
            var nuevoEmpleado = Mapper.Map<EmpleadoDto, Domain.Core.Entities.Empleado>(empleado);
            Uow.Repository<Domain.Core.Entities.Empleado>().Insert(nuevoEmpleado);
            Uow.Commit();
            
        }

        public void Update(EmpleadoDto empleado)
        {
            var empleadoModificar = Mapper.Map<EmpleadoDto, Domain.Core.Entities.Empleado>(empleado);
            Uow.Repository<Domain.Core.Entities.Empleado>().Update(empleadoModificar);
            Uow.Commit();
        }
    }
}
