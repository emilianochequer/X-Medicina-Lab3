using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base.Entity;
using Domain.Core.Entities.Validation;

namespace Domain.Core.Entities
{
    [Table("MotivoConsulta")]
    [MetadataType(typeof(IMotivoConsulta))]
    public class MotivoConsulta : BaseEntity
    {
        // Propiedades 
        public string Descripcion { get; set; }

        public bool EstaActivo { get; set; }
        // Propiedades de Navegacion
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
