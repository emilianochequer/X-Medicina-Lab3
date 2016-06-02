using System;
using System.Runtime.Serialization;
using Domain.Core.Entities.Enums;

namespace WcfService.Core.DTOs
{
    [DataContract]
    public class PacienteWcf
    {
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string ApyNom { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public string Domicilio { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Cecular { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public Sexo Sexo { get; set; }
        [DataMember]
        public GrupoSanguineo GrupoSanguineo { get; set; }
        [DataMember]
        public EstadoCivil EstadoCivil { get; set; }
        [DataMember]
        public string EsPrimeraVez { get; set; }
    }
}
