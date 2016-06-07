using Domain.Base.Entity;
using Domain.Core.Entities;
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
        public bool EstaActivo { get; set; }

        public DietaDescripcion DietaDescripcion { get; set; }


    }
}
