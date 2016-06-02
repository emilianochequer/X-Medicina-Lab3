using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Familiares.DTOs
{
    public class FamiliarDto
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Cecular { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
