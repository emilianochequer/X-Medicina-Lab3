using System.ComponentModel.DataAnnotations;

namespace Domain.Core.Entities.Validation
{
    public interface IAlimento
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        decimal Caloria { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        string Descripcion { get; set; }

    }
}
