using AutoMapper;

namespace LarTechAPi.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Domain.Entities.Person, DTOs.PersonDTO>().ReverseMap();
            CreateMap<Domain.Entities.Phone, DTOs.PhoneDTO>().ReverseMap();
        }
    }
}
