using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base.Entity;
using Domain.Core.Entities.Validation;

namespace Domain.Core.Entities
{
    [Table("ConfiguracionMail")]
    [MetadataType(typeof(IConfiguracionMail))]
    public class ConfiguracionMail : BaseEntity
    {
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public bool UsaSSL { get; set; }
        public string SMTPServer { get; set; }
        public int OutPort { get; set; }
        public string DireccionEnvia { get; set; }
        public bool EnviarAlCrearUsuario { get; set; }
        public bool EnviarAlCumplirAniosPaciente { get; set; }
        public bool EnviarAlCancelarTurno { get; set; }
    }
}
