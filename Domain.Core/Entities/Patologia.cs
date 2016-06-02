using Domain.Base.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.Validation;

namespace Domain.Core.Entities
{
    [Table("Patologia")]
    [MetadataType(typeof(IPatologia))]
    public class Patologia : BaseEntity
    {
        // Propiedades
        public string Descripcion { get; set; }

        public bool EstaActivo { get; set; }
        // Propiedades de Navegacion
        public virtual ICollection<Paciente> Pacientes {get; set; }
    }
}
