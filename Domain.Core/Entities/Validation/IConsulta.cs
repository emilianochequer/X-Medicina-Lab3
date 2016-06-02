using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Core.Entities.Validation
{
    public interface IConsulta
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        Guid MotivoConsultaId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        Guid PacienteId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        Guid ProfesionalId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.DateTime)]
        DateTime Fecha { get; set; }

        decimal? Peso { get; set; }
        decimal? Talle { get; set; }
        decimal? PerimetroCefalico { get; set; }

        decimal? Munieca { get; set; }
        decimal? Cintura { get; set; }
        decimal? Cadera { get; set; }
        decimal? MitadBrazoRelajado { get; set; }
        decimal? MitadBrazoContraido { get; set; }
        decimal? Cuello { get; set; }
        decimal? MesoEsternal { get; set; }
        decimal? Umbilical { get; set; }
        decimal? Muslo { get; set; }
        decimal? Pantorrilla { get; set; }
        decimal? Tobillo { get; set; }
        decimal? Antebrazo { get; set; }

        decimal? Biceps { get; set; }
        decimal? Triceps { get; set; }
        decimal? Subescupular { get; set; }
        decimal? Suprailisco { get; set; }
        decimal? Ileocrestal { get; set; }
        decimal? Abdominal { get; set; }
        decimal? MusloFrontal { get; set; }
        decimal? PantorrilaMedial { get; set; }
        decimal? AxilarMedial { get; set; }
        decimal? Pectoral { get; set; }

        [StringLength(4000,ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string DiagnosticoPresuntivo { get; set; }

        [StringLength(4000, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string DiagnosticoDefenitivo { get; set; }
    }
}
