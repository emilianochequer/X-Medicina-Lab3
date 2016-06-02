using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Core.Entities.Validation
{
    public interface IEmpleadoConfiguracion
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        Guid EmpleadoId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.DateTime)]
        DateTime FechaActualizacion { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Currency)]
        decimal MontoPrimeraVez { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Currency)]
        decimal MontoConsultaParticular { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Range(1, 480, ErrorMessage = "El campo {0} debe estar entre los valores {1} - {2}")]
        int IntervaloEntreTurnos { get; set; }
    }
}
