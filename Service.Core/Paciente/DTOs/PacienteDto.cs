using System;
using Domain.Core.Entities.Enums;

namespace Service.Core.Paciente.DTOs
{
    public class PacienteDto
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }

        public string ApyNom { get; set; }

        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Cecular { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Sexo Sexo { get; set; }
        public GrupoSanguineo GrupoSanguineo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }

        public string EsPrimeraVez { get; set; }
    }
}
