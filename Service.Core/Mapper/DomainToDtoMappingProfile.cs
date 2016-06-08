using System.Linq;
using AutoMapper;
using Service.Core.Paciente.DTOs;
using Service.Core.Alimento.DTOs;
using Service.Core.ObraSocial.DTOs;
using Service.Core.Consulta.DTOs;

namespace Service.Core.Mapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public override string ProfileName => "DomainToDtoMappings";

        protected override void Configure()
        {
            CreateMap<Domain.Core.Entities.Paciente, PacienteDto>()
                .ForMember(dto => dto.ApyNom, map => map.MapFrom(p => p.Apellido + " " + p.Nombre))
                .ForMember(dto => dto.EsPrimeraVez, map => map.MapFrom(p => p.Consultas.Any() ? "SI" : "No"));

            CreateMap<Domain.Core.Entities.Alimento, AlimentoDto>();
            CreateMap<Domain.Core.Entities.ObraSocial, ObraSocialDto>();
            CreateMap<Domain.Core.Entities.Consulta, ConsultaDto>();
            CreateMap<Domain.Core.Entities.Consulta, IMCxPersonaDto>()
                .ForMember(dto => dto.Fecha, map => map.MapFrom(p => p.Fecha))
                .ForMember(dto => dto.IMC, map => map.MapFrom(p => p.IMC));
        }
    }
}
