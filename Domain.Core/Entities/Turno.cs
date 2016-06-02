using Domain.Base.Entity;
using Domain.Core.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.Validation;

namespace Domain.Core.Entities
{
    [Table("Turno")]
    [MetadataType(typeof(ITurno))]
    public class Turno : BaseEntity
    {
        // Propiedades 
        public Guid PacienteId { get; set; }
        public Guid EmpleadoId { get; set; }
        public Guid ProfesionalId { get; set; }
        public Guid? ObraSocialId { get; set; }

        public EstadoTurno EstadoTurno { get; set; }

        public DateTime Fecha { get; set; }
        public DateTime HoraTurno { get; set; }
        public DateTime HoraAtendido { get; set; }
        public string NroOrden { get; set; }
        public string NroCupon { get; set; }
        public bool DebeObraSocial { get; set; }
        public bool Urgente { get; set; }
        public bool EsPrimeraVez { get; set; }
        public decimal Monto { get; set; }
        public string Observacion { get; set; }

        // Propiedades de navegacion
        [ForeignKey("PacienteId")]
        public virtual Paciente Paciente { get; set; }

        [ForeignKey("EmpleadoId")]
        public virtual Empleado Empleado { get; set; }

        [ForeignKey("ProfesionalId")]
        public virtual Empleado Profesional { get; set; }

        [ForeignKey("ObraSocialId")]
        public virtual ObraSocial ObraSocial { get; set; }
    }
}
