using System;
using System.ComponentModel.DataAnnotations;
using Domain.Core.Entities.Enums;

namespace Domain.Core.Entities.Validation
{
    public interface ITurno
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        Guid PacienteId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        Guid EmpleadoId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        Guid ProfesionalId { get; set; }

        Guid? ObraSocialId { get; set; }

        [EnumDataType(typeof (EstadoTurno))]
        EstadoTurno EstadoTurno { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        DateTime HoraTurno { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        DateTime HoraAtendido { get; set; }

        [StringLength(100, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        string NroOrden { get; set; }

        [StringLength(100, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        string NroCupon { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        bool DebeObraSocial { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        bool Urgente { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        bool EsPrimeraVez { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Currency)]
        decimal Monto { get; set; }

        [StringLength(400, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        string Observacion { get; set; }
    }
}
