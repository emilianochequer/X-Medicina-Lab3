using System.ComponentModel.DataAnnotations;
using Domain.Core.Entities.Enums;

namespace Domain.Core.Entities.Validation
{
    public interface ITablaCrecimiento
    {
        [EnumDataType(typeof(Sexo))]
        Sexo Sexo { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        int Anio { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        int Mes { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        decimal P3 { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        decimal P50 { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        decimal P97 { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        decimal T3 { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        decimal T50 { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        decimal T97 { get; set; }

        decimal? PcMax { get; set; }
        decimal? PcMin { get; set; }
        decimal? PcMedia { get; set; }
    }
}
