using AutoMapper;

namespace Service.Core.Mapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration MapperConfiguration;

        public static void Configure()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToDtoMappingProfile>();
                cfg.AddProfile<DtoToDomainMappingProfile>();
            });
        }
    }
}
