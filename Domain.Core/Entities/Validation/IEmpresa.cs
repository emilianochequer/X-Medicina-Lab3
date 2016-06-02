using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Core.Entities.Validation
{
    public interface IEmpresa
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        [StringLength(400, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string RazonSocial { get; set; }

        [StringLength(400, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string NombreFantasia { get; set; }

        [StringLength(15, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        string CuitCuil { get; set; }

        [StringLength(400, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        string Domicilio { get; set; }

        [StringLength(25, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string Telefono { get; set; }

        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        [DataType(DataType.EmailAddress)]
        string Mail { get; set; }

        [DataType(DataType.Date)]
        DateTime FechaInicioActividades { get; set; }
    }
}
