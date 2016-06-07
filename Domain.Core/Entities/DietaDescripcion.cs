using Domain.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Entities
{
   public class DietaDescripcion
    {
        public Guid DietaId { get; set; }
        public Guid AlimentoId { get; set; }
        public DiaDeLaSemana DiaDeLaSemana { get; set; }
        public Momentos Momentos { get; set; }

        public ICollection<Alimento> Alimento { get; set; }
        public Dieta Dieta { get; set; }
    }
}
