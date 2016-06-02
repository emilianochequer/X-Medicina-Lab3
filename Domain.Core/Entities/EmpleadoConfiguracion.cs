using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base.Entity;
using Domain.Core.Entities.Validation;

namespace Domain.Core.Entities
{
    [Table("EmpleadoConfiguracion")]
    [MetadataType(typeof(IEmpleadoConfiguracion))]
    public class EmpleadoConfiguracion : BaseEntity
    {
        // Propiedades
        public Guid EmpleadoId { get; set; }

        public DateTime FechaActualizacion { get; set; }
        public decimal MontoPrimeraVez { get; set; }
        public decimal MontoConsultaParticular { get; set; }
        public int IntervaloEntreTurnos { get; set; }

        // Propiedades de Navegacion
        public virtual Empleado Empleado { get; set; }
    }
}
