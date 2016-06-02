using System.ComponentModel.DataAnnotations;

namespace Domain.Core.Entities.Validation
{
    public interface IObraSocial
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        int Codigo { get; set; }

        [StringLength(50, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        string Abreviatura { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        string Descripcion { get; set; }
    }
}
