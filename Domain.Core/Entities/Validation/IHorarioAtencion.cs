using System;
using System.ComponentModel.DataAnnotations;
using Domain.Core.Entities.Enums;

namespace Domain.Core.Entities.Validation
{
    public interface IHorarioAtencion
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        Guid EmpleadoId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        Guid EmpresaId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Time)]
        DateTime HoraIn { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Time)]
        DateTime HoraOut { get; set; }

        [EnumDataType(typeof(TipoTurno))]
        TipoTurno TipoTurno { get; set; }

        [EnumDataType(typeof(DiaDeLaSemana))]
        DiaDeLaSemana DiaDeLaSemana { get; set; }
    }
}
