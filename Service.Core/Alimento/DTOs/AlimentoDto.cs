using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Alimento.DTOs
{
    public class AlimentoDto
    {
        public decimal Caloria { get; set; }
        public string Descripcion { get; set; }
        public bool EstaActivo { get; set; }
    }
}
