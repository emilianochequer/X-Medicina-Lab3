using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base.Entity;
using Domain.Core.Entities.Validation;

namespace Domain.Core.Entities
{
    [Table("ObraSocial")]
    [MetadataType(typeof(IObraSocial))]
    public class ObraSocial : BaseEntity
    {
        // Propiedades
        public int Codigo { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }

        public bool EstaActivo { get; set; }
        // Propiedades de Navegacion
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
