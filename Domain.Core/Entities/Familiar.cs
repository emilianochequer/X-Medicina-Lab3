using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base.Entity;
using Domain.Core.Entities.Validation;

namespace Domain.Core.Entities
{
    [Table("Familiar")]
    [MetadataType(typeof(IFamiliar))]
    public class Familiar : BaseEntity
    {
        // Propiedades
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Cecular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool EstaActivo { get; set; }
        // Propiedades de navegacion
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
