using Service.Core.Empleado.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Empleado
{
    public interface IEmpleadoService
    {
        void Insert(EmpleadoDto empleado);
        void Update(EmpleadoDto empleado);
        void Delete(Guid empleadoId);
        EmpleadoDto GetById(Guid empleadoId);
        IEnumerable<EmpleadoDto> GetByFilter(string cadena);
        IEnumerable<EmpleadoDto> GetAll();
    }
}
