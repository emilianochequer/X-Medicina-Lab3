using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Empresa.DTOs
{
    public class EmpresaDto
    {
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public string CuitCuil { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public DateTime FechaInicioActividades { get; set; }
    }
}
