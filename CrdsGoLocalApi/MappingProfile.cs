using AutoMapper;
using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, ContactDTO>()
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.EmailAddress))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.MobilePhone))
                .ForMember(dest => dest.BirthDate, opts => opts.MapFrom(src => src.DateOfBirth))
                .ReverseMap();
        }
    }
}