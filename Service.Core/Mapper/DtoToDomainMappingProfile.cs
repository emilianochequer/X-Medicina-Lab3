using AutoMapper;
using Service.Core.Alimento.DTOs;
using Service.Core.ObraSocial.DTOs;
using Service.Core.Paciente.DTOs;

namespace Service.Core.Mapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public override string ProfileName => "DtoToDomainMappings";

        protected override void Configure()
        {
            CreateMap<PacienteDto, Domain.Core.Entities.Paciente>();
            CreateMap<ObraSocialDto, Domain.Core.Entities.ObraSocial>();
            CreateMap<AlimentoDto, Domain.Core.Entities.Alimento>();
        }
    }
}
