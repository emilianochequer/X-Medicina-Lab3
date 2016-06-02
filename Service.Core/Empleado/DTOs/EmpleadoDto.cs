
using Domain.Core.Entities.Enums;
using System;

namespace Service.Core.Empleado.DTOs
{
    public class EmpleadoDto
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Cecular { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public TipoEmpleado TipoEmpleado { get; set; }
    }
}
