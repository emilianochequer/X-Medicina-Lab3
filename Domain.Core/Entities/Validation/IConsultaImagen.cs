using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Core.Entities.Validation
{
    public interface IConsultaImagen
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        Guid ConsultaId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        byte[] Imagen { get; set; }

        [StringLength(4000, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        string Observacion { get; set; }
    }
}
