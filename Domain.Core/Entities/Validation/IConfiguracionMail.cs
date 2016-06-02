using System.ComponentModel.DataAnnotations;

namespace Domain.Core.Entities.Validation
{
    public interface IConfiguracionMail
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        string NombreUsuario { get; set; }

        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        string Password { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        bool UsaSSL { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        string SMTPServer { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        int OutPort { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        string DireccionEnvia { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        bool EnviarAlCrearUsuario { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        bool EnviarAlCumplirAniosPaciente { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        bool EnviarAlCancelarTurno { get; set; }
    }
}
