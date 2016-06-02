using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base.Entity;
using Domain.Core.Entities.Validation;

namespace Domain.Core.Entities
{
    [Table("ConsultaImagen")]
    [MetadataType(typeof(IConsultaImagen))]
    public class ConsultaImagen : BaseEntity
    {
        // Propiedades
        public Guid ConsultaId { get; set; }

        public byte[] Imagen { get; set; }
        public string Observacion { get; set; }

        // Propiedades de Navegacion
        [ForeignKey("ConsultaId")]
        public virtual Consulta Consulta { get; set; }
    }
}
