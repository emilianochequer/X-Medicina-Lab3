using Domain.Base.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.Validation;

namespace Domain.Core.Entities
{
    [Table("Empresa")]
    [MetadataType(typeof(IEmpresa))]
    public class Empresa : BaseEntity
    {
        // Propiedades
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public string CuitCuil { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public DateTime FechaInicioActividades { get; set; }
        public bool EstaActivo { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<HorarioAtencion> HorarioAtenciones { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
