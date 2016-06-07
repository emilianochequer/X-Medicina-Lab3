using Service.Core.Consulta.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Consulta
{
   public interface IConsultaService
    {
        void Insert(ConsultaDto consulta);
        ConsultaDto Details(Guid consultaId);

    }
}
