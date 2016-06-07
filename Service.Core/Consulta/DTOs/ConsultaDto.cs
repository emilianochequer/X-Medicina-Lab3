using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Consulta.DTOs
{
    public class ConsultaDto
    {
        public Guid MotivoConsultaId { get; set; }
        public Guid PacienteId { get; set; }
        public Guid ProfesionalId { get; set; }

        public DateTime Fecha { get; set; }

        //Medidas Basicas
        public decimal? Peso { get; set; }
        public decimal? Talle { get; set; }

        //Circunferencias
        public decimal? Cintura { get; set; }
        public decimal? Cadera { get; set; }

        public decimal? MitadBrazoRelajado { get; set; }
        public decimal? MitadBrazoContraido { get; set; }
        public decimal? Cuello { get; set; }
        public decimal? Muslo { get; set; }


        //Pliegues
        public decimal? Biceps { get; set; }
        public decimal? Triceps { get; set; }
        public decimal? Subescupular { get; set; }
        public decimal? Abdominal { get; set; }
        public decimal? MusloFrontal { get; set; }


        //Indices
        public decimal? IMC { get; set; }
        public decimal? IndiceCaderaCintura { get; set; }
        public decimal? IndiceGrasaCorporal { get; set; }
        public decimal? PesoIdeal { get; set; }

    }
}
