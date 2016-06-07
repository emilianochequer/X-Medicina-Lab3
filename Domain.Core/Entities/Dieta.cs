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

        //              lunes                 //
        public string LunesDesayuno { get; set; }
        public string LunesMediaMa { get; set; }
        public string LunesAlmuerzo { get; set; }
        public string LunesMediaTa { get; set; }
        public string LunesCena { get; set; }

        //              martes                //
        public string MartesDesayuno { get; set; }
        public string MartesMediaMa { get; set; }
        public string MartesAlmuerzo { get; set; }
        public string MartesMediaTa { get; set; }
        public string MartesCena { get; set; }

        //              miercoles                //
        public string MiercolesDesayuno { get; set; }
        public string MiercolesMediaMa { get; set; }
        public string MiercolesAlmuerzo { get; set; }
        public string MiercolesMediaTa { get; set; }
        public string MiercolesCena { get; set; }

        //              jueves                //
        public string JuevesDesayuno { get; set; }
        public string JuevesMediaMa { get; set; }
        public string JuevesAlmuerzo { get; set; }
        public string JuevesMediaTa { get; set; }
        public string JuevesCena { get; set; }

        //              viernes                //
        public string ViernesDesayuno { get; set; }
        public string ViernesMediaMa { get; set; }
        public string ViernesAlmuerzo { get; set; }
        public string ViernesMediaTa { get; set; }
        public string ViernesCena { get; set; }

        //              sabado                //
        public string SabadoDesayuno { get; set; }
        public string SabadoMediaMa { get; set; }
        public string SabadoAlmuerzo { get; set; }
        public string SabadoMediaTa { get; set; }
        public string SabadoCena { get; set; }

        //              domingo                //
        public string DomingoDesayuno { get; set; }
        public string DomingoMediaMa { get; set; }
        public string DomingoAlmuerzo { get; set; }
        public string DomingoMediaTa { get; set; }
        public string DomingoCena { get; set; }




    }
}
