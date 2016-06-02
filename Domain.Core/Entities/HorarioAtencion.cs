using Domain.Base.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.Enums;
using Domain.Core.Entities.Validation;

namespace Domain.Core.Entities
{
    [Table("HorarioAtencion")]
    [MetadataType(typeof(IHorarioAtencion))]
    public class HorarioAtencion : BaseEntity
    {
        // Propiedades
        public Guid EmpleadoId { get; set; }
        public Guid EmpresaId { get; set; }
        
        public DateTime HoraIn { get; set; }
        public DateTime HoraOut { get; set; }

        public TipoTurno TipoTurno { get; set; }
        public DiaDeLaSemana DiaDeLaSemana { get; set; }

        // Propiedades de Navegacion
        [ForeignKey("EmpleadoId")]
        public virtual Empleado Empleado { get; set; }

        [ForeignKey("EmpresaId")]
        public virtual Empresa Empresa { get; set; }
    }
}
