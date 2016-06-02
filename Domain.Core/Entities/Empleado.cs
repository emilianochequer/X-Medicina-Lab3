using Domain.Base.Entity;
using Domain.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.Validation;

namespace Domain.Core.Entities
{
    [Table("Empleado")]
    [MetadataType(typeof (IEmpleado))]
    public class Empleado : BaseEntity
    {
        // Propiedades
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Cecular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool EstaActivo { get; set; }

        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public TipoEmpleado TipoEmpleado { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<HorarioAtencion> HorarioAtenciones { get; set; }
        public virtual ICollection<EmpleadoConfiguracion> EmpleadoConfiguraciones { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }

        [InverseProperty("Empleado")]
        public virtual ICollection<Turno> TurnosEmpleados { get; set; }

        [InverseProperty("Profesional")]
        public virtual ICollection<Turno> TurnosProfesionales { get; set; }
    }
}
