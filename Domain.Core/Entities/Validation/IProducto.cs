using System.ComponentModel.DataAnnotations;

namespace Domain.Core.Entities.Validation
{
    public interface IProducto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        string Descripcion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        string Monodroga { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Currency)]
        decimal PrecioVenta { get; set; }
    }
}
