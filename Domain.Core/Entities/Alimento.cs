using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base.Entity;
using Domain.Core.Entities.Validation;

namespace Domain.Core.Entities
{
    [Table("Alimento")]
    [MetadataType(typeof(IAlimento))]
     public class Alimento : BaseEntity
    {

        public decimal Caloria { get; set; }
        public string Descripcion { get; set; }
        public bool EstaActivo { get; set; }

    }
}
