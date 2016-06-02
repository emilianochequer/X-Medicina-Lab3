using Domain.Base.Entity;
using Domain.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.Validation;

namespace Domain.Core.Entities
{
    [Table("Paciente")]
    [MetadataType(typeof(IPaciente))]
    public class Paciente : BaseEntity
    {
        // Propiedades
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Cecular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Mail { get; set; }
        public bool EstaActivo { get; set; }
        
        public Sexo Sexo { get; set; }
        public GrupoSanguineo GrupoSanguineo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Patologia> Patologias { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
        public virtual ICollection<Familiar> Familiares  { get; set; }
    }
}
