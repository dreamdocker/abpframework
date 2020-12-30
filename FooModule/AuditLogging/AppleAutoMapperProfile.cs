using AutoMapper;

namespace FooModule.AuditLogging
{
    public class AppleAutoMapperProfile : Profile
    {
        public AppleAutoMapperProfile()
        {
            CreateMap<Apple, AppleDto>();
            CreateMap<AppleDto, Apple>();
        }
    }
}
