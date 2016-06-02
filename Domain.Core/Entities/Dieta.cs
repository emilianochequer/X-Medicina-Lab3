using Domain.Base.Entity;
using Domain.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class Dieta : BaseEntity
    {
        //propiedades 
        public DateTime FechaDesde  { get; set; }
        public DateTime FechaHasta { get; set; }
        public Guid PacienteId { get; set; }
        public Guid AlimentoId { get; set; }
        public Momentos Momento { get; set; }
        public DiaDeLaSemana DiaDeLaSemana { get; set; }


    }
}
